using System;
using System.Collections.Generic;
using System.Linq;
using ConnectFourGame.Board;
using ConnectFourGame.Exceptions;
using ConnectFourGame.Player.AiAttributes;
using Newtonsoft.Json;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Candidate solution for a connect four player.
    /// </summary>
    public class AiPlayer : IPlayer, IAiPlayer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("generation")]
        public long Generation { get; set; }

        [JsonProperty("characteristics")]
        public Characteristics Characteristics { get; set; }

        [JsonProperty("scores")]
        public Scores Scores { get; set; }

        public int GamePiece { get; set; }

        public long LastGameScore { get; set; }

        private readonly Random _rand;

        /// <summary>
        /// Create an AI Player
        /// </summary>
        /// <param name="characteristics">Characteristics of the AI player.</param>
        /// <param name="previousScores">Scores from previous runs.</param>
        public AiPlayer(Characteristics characteristics, Scores previousScores = null)
        {
            Characteristics = characteristics;
            Scores = previousScores;
            _rand = new Random();
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public Point MakeMove(IBoard board)
        {
            if (GamePiece == Board.Board.DefaultBoardValue)
            {
                throw new GamePieceNotSetException($"{Id} does not have a game piece.");
            }

            return board.AddPiece(new GameMove(GamePiece, PickNextMoveColumn(board)));
        }

        /// <summary>
        /// Analyse move options and return the column index this player thinks will be best.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Column index for next move.</returns>
        public int PickNextMoveColumn(IBoard board)
        {
            if (board.IsFull())
            {
                throw new BoardFullException();
            }

            return GetHighestScoringColumnIndex(board);
        }

        /// <summary>
        /// Get the column with the highest score.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        public int GetHighestScoringColumnIndex(IBoard board)
        {
            long? highestScoringColumnScore = null;
            var highestScoringColumnIndexes = new List<int>();
            
            // Keep track of all equally high scoring columns
            for (int columnIndex = 0; columnIndex < board.GetColumnCount(); columnIndex++)
            {
                if (!board.IsColumnFull(columnIndex))
                {
                    var columnScore = GetColumnScoreAfterPotentialMove(board, columnIndex);
                    if (highestScoringColumnScore == null)
                    {
                        highestScoringColumnScore = columnScore;
                        highestScoringColumnIndexes.Add(columnIndex);
                    }
                    else if (columnScore == highestScoringColumnScore)
                    {
                        highestScoringColumnIndexes.Add(columnIndex);
                    }
                    else if (columnScore > highestScoringColumnScore)
                    {
                        highestScoringColumnScore = columnScore;
                        highestScoringColumnIndexes.Clear();
                        highestScoringColumnIndexes.Add(columnIndex); 
                    }
                }
            }

            // Randomly pick one of the highest scoring columns
            var highestScoringColumnIndex = highestScoringColumnIndexes.Count == 1 ? highestScoringColumnIndexes.First() : highestScoringColumnIndexes[_rand.Next(0, highestScoringColumnIndexes.Count-1)];
            return highestScoringColumnIndex;
        }

        /// <summary>
        /// Get the players self defined score of the current state of the board.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Score of the board.</returns>
        public long GetBoardScore(IBoard board)
        {
            long boardScore = 0;
            IBoardAnalytics boardAnalytics = new BoardAnalytics();

            var opponentsGamePiece = GamePiece == ConnectFourGame.PlayerOneGamePiece
                ? ConnectFourGame.PlayerTwoGamePiece
                : ConnectFourGame.PlayerOneGamePiece;

            // Get score for making the move
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.TwoInARow, GamePiece, board) * Characteristics.ScoreConnectTwo;
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.ThreeInARow, GamePiece, board) * Characteristics.ScoreConnectThree;
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.FourInARow, GamePiece, board) * Characteristics.ScoreConnectFour;

            // Subtract points for the potential move the opponent gets
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.TwoInARow, opponentsGamePiece, board) * Characteristics.ScoreGivingConnectTwo;
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.ThreeInARow, opponentsGamePiece, board) * Characteristics.ScoreGivingConnectThree;
            boardScore += boardAnalytics.NumberOfPiecesInARowOnBoard(Board.Board.FourInARow, opponentsGamePiece, board) * Characteristics.ScoreGivingConnectFour;

            return boardScore;
        }

        /// <summary>
        /// Get the players self defined score of a column index as its next move.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <param name="columnIndexForPotentialMove">Column index for next potential move.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        public long GetColumnScoreAfterPotentialMove(IBoard board, int columnIndexForPotentialMove)
        {
            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            long finalScore = 0;

            // Get score for making the move
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(GamePiece, columnIndexForPotentialMove), board)
                          * Characteristics.ScoreConnectTwo;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(GamePiece, columnIndexForPotentialMove), board)
                          * Characteristics.ScoreConnectThree;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(GamePiece, columnIndexForPotentialMove), board)
                          * Characteristics.ScoreConnectFour;

            // Setup for checking opponents potential move
            IBoard boardAfterPotentialMove = board.Clone();
            boardAfterPotentialMove.AddPiece(new GameMove(GamePiece, columnIndexForPotentialMove));
            var opponentsGamePiece = GamePiece == ConnectFourGame.PlayerOneGamePiece
                ? ConnectFourGame.PlayerTwoGamePiece
                : ConnectFourGame.PlayerOneGamePiece;

            // Subtract points for the potential move the opponent gets
            if (!boardAfterPotentialMove.IsColumnFull(columnIndexForPotentialMove))
            {
                finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(opponentsGamePiece, columnIndexForPotentialMove), boardAfterPotentialMove)
                              * Characteristics.ScoreGivingConnectTwo;
                finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(opponentsGamePiece, columnIndexForPotentialMove), boardAfterPotentialMove)
                              * Characteristics.ScoreGivingConnectThree;
                finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(opponentsGamePiece, columnIndexForPotentialMove), boardAfterPotentialMove)
                              * Characteristics.ScoreGivingConnectFour;
            }

            return finalScore;
        }
    }
}

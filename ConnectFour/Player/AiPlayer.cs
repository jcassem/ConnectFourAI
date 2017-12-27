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

        private int GamePiece { get; set; }

        /// <summary>
        /// Create an AI Player
        /// </summary>
        /// <param name="characteristics">Characteristics of the AI player.</param>
        /// <param name="previousScores">Scores from previous runs.</param>
        public AiPlayer(Characteristics characteristics, Scores previousScores = null)
        {
            Characteristics = characteristics;
            Scores = previousScores;
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

            long highestScoringColumnScore = -1;
            var highestScoringColumnIndex = 0;

            for (int columnIndex = 0; columnIndex < board.GetColumnCount(); columnIndex++)
            {
                if (!board.IsColumnFull((columnIndex)))
                {
                    var columnScore = GetColumnScore(board, columnIndex);
                    if (columnScore > highestScoringColumnScore)
                    {
                        highestScoringColumnScore = columnScore;
                        highestScoringColumnIndex = columnIndex;
                    }
                }
            }

            return highestScoringColumnIndex;
        }

        /// <summary>
        /// Get the players self defined score of a column index as its next move.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        public long GetColumnScore(IBoard board, int columnIndex)
        {
            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            long finalScore = 0;

            // Get score for making the move
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreConnectTwo;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreConnectThree;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreConnectThree;

            // Setup for checking opponents potential move
            IBoard boardAfterPotentialMove = board.Clone();
            boardAfterPotentialMove.AddPiece(new GameMove(GamePiece, columnIndex));
            var opponentsGamePiece = GamePiece == ConnectFourGame.PlayerOneGamePiece
                ? ConnectFourGame.PlayerTwoGamePiece
                : ConnectFourGame.PlayerOneGamePiece;

            // Subtract points for the potential move the opponent gets
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreGivingConnectTwo;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreGivingConnectThree;
            finalScore += boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreGivingConnectFour;

            return finalScore;
        }
    }
}

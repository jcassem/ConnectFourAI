using ConnectFourGame.Board;
using ConnectFourGame.Exceptions;
using ConnectFourGame.Player.AiAttributes;
using Newtonsoft.Json;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Candidate solution for a connect four player.
    /// </summary>
    public class AiPlayer : AbstractPlayer, IAiPlayer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("generation")]
        public long Generation { get; set; }

        [JsonProperty("characteristics")]
        public Characteristics Characteristics { get; set; }

        [JsonProperty("scores")]
        public Scores Scores { get; set; }

        private readonly IBoardAnalytics _boardAnalytics;

        /// <summary>
        /// Create an AI Player
        /// </summary>
        /// <param name="gamePiece">Game piece to represent this player.</param>
        /// <param name="characteristics">Characteristics of the AI player.</param>
        /// <param name="previousScores">Scores from previous runs.</param>
        public AiPlayer(int gamePiece, Characteristics characteristics, Scores previousScores = null) : base(gamePiece)
        {
            _boardAnalytics = new BoardAnalytics();
            Characteristics = characteristics;
            Scores = previousScores;
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public override Point MakeMove(IBoard board)
        {
            if (GamePiece == Board.Board.DefaultBoardValue)
            {
                throw new GamePieceNotSetException($"{Name} does not have a game piece.");
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
            long finalScore = 0;

            // Get score for making the move
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreForTwoInARow;
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreForThreeInARow;
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(GamePiece, columnIndex), board)
                          * Characteristics.ScoreForFourInARow;

            // Setup for checking opponents potential move
            IBoard boardAfterPotentialMove = board.Clone();
            boardAfterPotentialMove.AddPiece(new GameMove(GamePiece, columnIndex));
            var opponentsGamePiece = GamePiece == ConnectFourGame.PlayerOneGamePiece
                ? ConnectFourGame.PlayerTwoGamePiece
                : ConnectFourGame.PlayerOneGamePiece;

            // Subtract points for the potential move the opponent gets
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.TwoInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreForGivingOpponentTwoInARow;
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.ThreeInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreForGivingOpponentThreeInARow;
            finalScore += _boardAnalytics.NumberOfPiecesInARowOnBoardFromPotentialMove(Board.Board.FourInARow, new GameMove(opponentsGamePiece, columnIndex), board)
                          * Characteristics.ScoreForGivingOpponentFourInARow;

            return finalScore;
        }
    }
}

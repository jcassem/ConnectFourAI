using ConnectFourGame.Board;
using ConnectFourGame.Exceptions;
using System;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Candidate solution for a connect four player.
    /// </summary>
    public class AiPlayer : Player, IAiPlayer
    {
        private IBoardAnalytics _boardAnalytics;
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public AiPlayer(string name, int gamePiece) : base(name, gamePiece)
        {
            _boardAnalytics = new BoardAnalytics();
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public override Point MakeMove(IBoard board)
        {
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

            int highestScoringColumnScore = -1;
            int highestScoringColumnIndex = 0;

            for (int columnIndex = 0; columnIndex < board.GetColumnCount(); columnIndex++)
            {
                var columnScore = 0;
                if (!board.IsColumnFull((columnIndex)))
                {
                    columnScore = GetColumnScore(board, columnIndex);
                    if (columnScore > highestScoringColumnScore)
                    {
                        highestScoringColumnScore = columnScore;
                        highestScoringColumnIndex = columnIndex;
                    }
                }
                //Console.WriteLine($"-- {Name} on index {columnIndex} has score {columnScore} against high score {highestScoringColumnScore} from column {highestScoringColumnIndex}");
            }

            return highestScoringColumnIndex;
        }

        /// <summary>
        /// Get the players self defined score of a column index as its next move.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        public int GetColumnScore(IBoard board, int columnIndex)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(0, 100);
            }
        }
    }
}

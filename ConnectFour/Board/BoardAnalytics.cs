using ConnectFourGame.Exceptions;

namespace ConnectFourGame.Board
{
    /// <summary>
    /// Tools to gather statistics and analysis on the current and potential state of a Connect four game board.
    /// </summary>
    public class BoardAnalytics : IBoardAnalytics
    {
        /// <summary>
        /// Counts the number of runs of game pieces in a row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs on a board.</returns>
        public int NumberOfPiecesInARowOnBoard(int piecesInARow, int gamePiece, IBoard board)
        {
            return NumberOfHorizontalRunsOnBoard(piecesInARow, gamePiece, board)
                + NumberOfVerticalRunsOnBoard(piecesInARow, gamePiece, board)
                + NumberOfForwardDiagonalRunsOnBoard(piecesInARow, gamePiece, board)
                + NumberOfBackwardDiagonalRunsOnBoard(piecesInARow, gamePiece, board);
        }

        /// <summary>
        /// Counts the number of runs of game pieces in a row on a board after a potential move.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="potentialMove">Potential move to do before running analytics.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs on a board.</returns>
        public int NumberOfPiecesInARowOnBoardFromPotentialMove(int piecesInARow, GameMove potentialMove, IBoard board)
        {
            if (board.IsColumnFull(potentialMove.BoardColumn))
            {
                throw new BoardColumnFullException("Column:" + potentialMove.BoardColumn);
            }

            var clonedBoard = board.Clone();
            clonedBoard.AddPiece(potentialMove);
            return NumberOfPiecesInARowOnBoard(piecesInARow, potentialMove.GamePiece, clonedBoard);
        }

        /// <summary>
        /// Counts the number of runs of game pieces in a horizontal row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs in a horizontal row on a board.</returns>
        private int NumberOfHorizontalRunsOnBoard(int piecesInARow, int gamePiece, IBoard board)
        {
            int[,] gameBoard = board.GetBoard();
            int totalRunCount = 0;

            for (int row = 0; row < board.GetRowCount(); row++)
            {
                int runCount = 0;
                var col = 0;

                while (gameBoard[col, row].Equals(gamePiece) && col < board.GetColumnCount())
                {
                    runCount++;
                    col++;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            return totalRunCount;
        }

        /// <summary>
        /// Counts the number of runs of game pieces in a vertical row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs in a vertical row on a board.</returns>
        private int NumberOfVerticalRunsOnBoard(int piecesInARow, int gamePiece, IBoard board)
        {
            var gameBoard = board.GetBoard();
            var totalRunCount = 0;

            for (int col = 0; col < board.GetColumnCount(); col++)
            {
                var runCount = 0;
                var row = 0;

                while (gameBoard[col, row].Equals(gamePiece) && row < board.GetRowCount())
                {
                    runCount++;
                    row++;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            return totalRunCount;
        }

        /// <summary>
        /// Counts the number of runs of game pieces in a forward diagonal row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs in a forward diagonal row on a board.</returns>
        private int NumberOfForwardDiagonalRunsOnBoard(int piecesInARow, int gamePiece, IBoard board)
        {
            int[,] gameBoard = board.GetBoard();
            int totalRunCount = 0;
            int row, column, runCount;

            // Check top left section of board.
            for (int i = 0; i < board.GetRowCount() - piecesInARow - 1; i++)
            {
                column = 0;
                row = i;
                runCount = 0;

                while (row < board.GetRowCount() && column < board.GetColumnCount())
                {
                    if (gameBoard[column, row].Equals(gamePiece))
                    {
                        runCount++;
                    }
                    row++;
                    column++;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            // Check bottom right section of board.
            for (int i = 1; i < board.GetColumnCount() - piecesInARow - 1; i++)
            {
                column = i;
                row = 0;
                runCount = 0;

                while (row < board.GetRowCount() && column < board.GetColumnCount())
                {
                    if (gameBoard[column, row].Equals(gamePiece))
                    {
                        runCount++;
                    }
                    row++;
                    column++;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            return totalRunCount;
        }

        /// <summary>
        /// Counts the number of runs of game pieces in a backward diagonal row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs in a backward diagonal row on a board.</returns>
        private int NumberOfBackwardDiagonalRunsOnBoard(int piecesInARow, int gamePiece, IBoard board)
        {
            int[,] gameBoard = board.GetBoard();
            int totalRunCount = 0;
            int row, column, runCount;

            // Check top right section of board.
            for (int i = 0; i < board.GetRowCount() - piecesInARow - 1; i++)
            {
                column = board.GetColumnCount() - 1;
                row = i;
                runCount = 0;

                while (row < board.GetRowCount() && column > 0)
                {
                    if (gameBoard[column, row].Equals(gamePiece))
                    {
                        runCount++;
                    }
                    row++;
                    column--;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            // Check bottom left section of board.
            for (int i = piecesInARow - 1; i < board.GetColumnCount() - 1; i++)
            {
                column = i;
                row = 0;
                runCount = 0;

                while (row < board.GetRowCount() && column > 0)
                {
                    if (gameBoard[column, row].Equals(gamePiece))
                    {
                        runCount++;
                    }
                    row++;
                    column--;
                }

                if (runCount == piecesInARow)
                {
                    totalRunCount++;
                }
            }

            return totalRunCount;
        }
    }
}

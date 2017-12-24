using ConnectFour.Exceptions;
using ConnectFourGame;
using System;

namespace ConnectFour
{
    /// <summary>
    /// Connect four game board.
    /// </summary>
    public class Board : IBoard
    {
        public const int FOUR_IN_A_ROW = 4;

        public const int DEFAULT_BOARD_VALUE = 0;

        private int[,] BoardGrid;

        public int ColumnSize;

        public int RowSize;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Columns">Number of columns in the board.</param>
        /// <param name="Rows">Number of rows in the board.</param>
        public Board(int Columns, int Rows)
        {
            ColumnSize = Columns;
            RowSize = Rows;
            BoardGrid = new int[ColumnSize, RowSize];
        }

        /// <summary>
        /// Checks if board has four of the same game pieces in a row.
        /// Either horizontally, vertically or diagonally.
        /// </summary>
        /// <param name="lastMove">Last move in the game (for efficient processing).</param>
        /// <returns>Whether game board has gour of the same game pieces in a row.</returns>
        public bool HasConnectFour(Point lastMove)
        {
            return HasHorizontalFour(lastMove)
                || HasVerticalFour(lastMove)
                || HasForwardDiagonalFour(lastMove)
                || HasBackwardDiagonalFour(lastMove);
        }

        /// <summary>
        /// Adds a players game piece representation to the board.
        /// </summary>
        /// <param name="gamePiece">Game piece to add.</param>
        /// <param name="column">Column on the board to add it to.</param>
        public Point AddPiece(GameMove playersMove)
        {
            if (IsColumnFull(playersMove.boardColumn))
            {
                throw new BoardColumnFullException($"Column index: {playersMove.boardColumn}");
            }

            if (playersMove.gamePiece == DEFAULT_BOARD_VALUE)
            {
                throw new AddDefaultValueAsGamePieceException();
            }

            int row = 0;
            while (BoardGrid[playersMove.boardColumn, row] != DEFAULT_BOARD_VALUE)
            {
                row++;
            }
            BoardGrid[playersMove.boardColumn, row] = playersMove.gamePiece;
            return new Point(playersMove.boardColumn, row);
        }

        /// <summary>
        /// Checks if a column on the game board is full of game pieces.
        /// </summary>
        /// <param name="column">Column on game board to check.</param>
        /// <returns>Whether column on game board is full.</returns>
        public bool IsColumnFull(int column)
        {
            return BoardGrid[column, RowSize - 1] != DEFAULT_BOARD_VALUE;
        }

        /// <summary>
        /// Checks if the whole board is full of game pieces.
        /// </summary>
        /// <returns>Whether the board is full of game pieces.</returns>
        public bool IsFull()
        {
            for (int i = 0; i < ColumnSize; i++)
            {
                if (!IsColumnFull(i))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the last game piece added is apart of a horizontal group of four.
        /// </summary>
        /// <param name="lastMove">Last move co-ordinates.</param>
        /// <returns>Last game piece added to board is apart of a group of four.</returns>
        public bool HasHorizontalFour(Point lastMove)
        {
            if (lastMove == null)
            {
                return false;
            }

            int lastPlayedGamePiece = BoardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going right
            int columnIndex = lastMove.ColumnIndex + 1;
            while (columnIndex < ColumnSize && count < FOUR_IN_A_ROW)
            {
                if (!BoardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                columnIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going left
                columnIndex = lastMove.ColumnIndex - 1;
                while (columnIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (!BoardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    columnIndex--;
                }
            }

            Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has horizonal:{count}");
            return count == FOUR_IN_A_ROW;
        }

        /// <summary>
        /// Checks if the last game piece added is apart of a vertical group of four.
        /// </summary>
        /// <param name="lastMove">Last move co-ordinates.</param>
        /// <returns>Last game piece added to board is apart of a group of four.</returns>
        public bool HasVerticalFour(Point lastMove)
        {
            if (lastMove == null)
            {
                return false;
            }

            int lastPlayedGamePiece = BoardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going upward
            int rowIndex = lastMove.RowIndex + 1;
            while (rowIndex < RowSize && count < FOUR_IN_A_ROW)
            {
                if (!BoardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going downwards
                rowIndex = lastMove.RowIndex - 1;
                while (rowIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (!BoardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                }
            }

            Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) vertical: {count}");
            return count == FOUR_IN_A_ROW;
        }

        /// <summary>
        /// Checks if the last game piece added is apart of a forward diagonal group of four.
        /// </summary>
        /// <param name="lastMove">Last move co-ordinates.</param>
        /// <returns>Last game piece added to board is apart of a group of four.</returns>
        public bool HasForwardDiagonalFour(Point lastMove)
        {
            if (lastMove == null)
            {
                return false;
            }

            int lastPlayedGamePiece = BoardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going up to the right
            int rowIndex = lastMove.RowIndex + 1;
            int columnIndex = lastMove.ColumnIndex + 1;
            while (rowIndex < RowSize && columnIndex < ColumnSize && count < FOUR_IN_A_ROW)
            {
                if (!BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
                columnIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going down to the left
                rowIndex = lastMove.RowIndex - 1;
                columnIndex = lastMove.ColumnIndex - 1;
                while (rowIndex >= 0 && columnIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (!BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                    columnIndex--;
                }
            }

            Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has forward diagonal: {count}");
            return count == FOUR_IN_A_ROW;
        }

        /// <summary>
        /// Checks if the last game piece added is apart of a backward diagonal group of four.
        /// </summary>
        /// <param name="lastMove">Last move co-ordinates.</param>
        /// <returns>Last game piece added to board is apart of a group of four.</returns>
        public bool HasBackwardDiagonalFour(Point lastMove)
        {
            if (lastMove == null)
            {
                return false;
            }

            int lastPlayedGamePiece = BoardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going up to the left
            int rowIndex = lastMove.RowIndex + 1;
            int columnIndex = lastMove.ColumnIndex - 1;
            while (rowIndex < RowSize && columnIndex >= 0 && count < FOUR_IN_A_ROW)
            {
                if (!BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
                columnIndex--;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going down to the right
                rowIndex = lastMove.RowIndex - 1;
                columnIndex = lastMove.ColumnIndex + 1;
                while (rowIndex >= 0 && columnIndex < ColumnSize && count < FOUR_IN_A_ROW)
                {
                    if (!BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                    columnIndex++;
                }
            }

            Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has backward diagonal: {count}");
            return count == FOUR_IN_A_ROW;
        }

        /// <summary>
        /// Gets the integer array of the game board.
        /// </summary>
        /// <returns>Game board.</returns>
        public int[,] GetBoard()
        {
            return BoardGrid.Clone() as int[,];
        }

        /// <summary>
        /// Returns number of columns in the board.
        /// </summary>
        /// <returns>Number of columns in board.</returns>
        public int GetColumnCount()
        {
            return ColumnSize;
        }

        /// <summary>
        /// Returns number of rows in the board.
        /// </summary>
        /// <returns>Number of rows in board.</returns>
        public int GetRowCount()
        {
            return RowSize;
        }

        private void SetBoardGrid(int[,] boardGrid)
        {
            this.BoardGrid = boardGrid;
        }

        /// <summary>
        /// Create a duplicate of this board.
        /// </summary>
        /// <returns>Cloned board.</returns>
        public IBoard Clone()
        {
            Board board = new Board(ColumnSize, RowSize);
            board.SetBoardGrid(this.BoardGrid);
            return board;
        }
    }
}

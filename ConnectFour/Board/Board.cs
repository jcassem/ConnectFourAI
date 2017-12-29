using ConnectFourGame.Exceptions;

namespace ConnectFourGame.Board
{
    /// <summary>
    /// Connect four game board.
    /// </summary>
    public class Board : IBoard
    {
        public const int FourInARow = 4;

        public const int ThreeInARow = 3;

        public const int TwoInARow = 2;

        public const int DefaultBoardValue = 0;

        private int[,] _boardGrid;

        public int ColumnSize;

        public int RowSize;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columns">Number of columns in the board.</param>
        /// <param name="rows">Number of rows in the board.</param>
        public Board(int columns, int rows)
        {
            ColumnSize = columns;
            RowSize = rows;
            _boardGrid = new int[ColumnSize, RowSize];
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
        /// <param name="playersMove">Game piece and column to add.</param>
        public Point AddPiece(GameMove playersMove)
        {
            if (IsColumnFull(playersMove.BoardColumn))
            {
                throw new BoardColumnFullException($"Column index: {playersMove.BoardColumn}");
            }

            if (playersMove.GamePiece == DefaultBoardValue)
            {
                throw new AddDefaultValueAsGamePieceException();
            }

            var row = 0;
            while (_boardGrid[playersMove.BoardColumn, row] != DefaultBoardValue)
            {
                row++;
            }
            _boardGrid[playersMove.BoardColumn, row] = playersMove.GamePiece;

            return new Point(playersMove.BoardColumn, row);
        }

        /// <summary>
        /// Checks if a column on the game board is full of game pieces.
        /// </summary>
        /// <param name="column">Column on game board to check.</param>
        /// <returns>Whether column on game board is full.</returns>
        public bool IsColumnFull(int column)
        {
            return _boardGrid[column, RowSize - 1] != DefaultBoardValue;
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

            int lastPlayedGamePiece = _boardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going right
            int columnIndex = lastMove.ColumnIndex + 1;
            while (columnIndex < ColumnSize && count < FourInARow)
            {
                if (!_boardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                columnIndex++;
            }

            if (count != FourInARow)
            {
                // Check run going left
                columnIndex = lastMove.ColumnIndex - 1;
                while (columnIndex >= 0 && count < FourInARow)
                {
                    if (!_boardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    columnIndex--;
                }
            }

            // Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has horizonal:{count}");
            return count == FourInARow;
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

            int lastPlayedGamePiece = _boardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going upward
            int rowIndex = lastMove.RowIndex + 1;
            while (rowIndex < RowSize && count < FourInARow)
            {
                if (!_boardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
            }

            if (count != FourInARow)
            {
                // Check run going downwards
                rowIndex = lastMove.RowIndex - 1;
                while (rowIndex >= 0 && count < FourInARow)
                {
                    if (!_boardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                }
            }

            // Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) vertical: {count}");
            return count == FourInARow;
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

            int lastPlayedGamePiece = _boardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going up to the right
            int rowIndex = lastMove.RowIndex + 1;
            int columnIndex = lastMove.ColumnIndex + 1;
            while (rowIndex < RowSize && columnIndex < ColumnSize && count < FourInARow)
            {
                if (!_boardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
                columnIndex++;
            }

            if (count != FourInARow)
            {
                // Check run going down to the left
                rowIndex = lastMove.RowIndex - 1;
                columnIndex = lastMove.ColumnIndex - 1;
                while (rowIndex >= 0 && columnIndex >= 0 && count < FourInARow)
                {
                    if (!_boardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                    columnIndex--;
                }
            }

            // Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has forward diagonal: {count}");
            return count == FourInARow;
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

            int lastPlayedGamePiece = _boardGrid[lastMove.ColumnIndex, lastMove.RowIndex];
            int count = 1;

            // Check run going up to the left
            int rowIndex = lastMove.RowIndex + 1;
            int columnIndex = lastMove.ColumnIndex - 1;
            while (rowIndex < RowSize && columnIndex >= 0 && count < FourInARow)
            {
                if (!_boardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    break;
                }
                count++;
                rowIndex++;
                columnIndex--;
            }

            if (count != FourInARow)
            {
                // Check run going down to the right
                rowIndex = lastMove.RowIndex - 1;
                columnIndex = lastMove.ColumnIndex + 1;
                while (rowIndex >= 0 && columnIndex < ColumnSize && count < FourInARow)
                {
                    if (!_boardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        break;
                    }
                    count++;
                    rowIndex--;
                    columnIndex++;
                }
            }

            // Console.WriteLine($"Player {lastPlayedGamePiece} from move ({lastMove.ColumnIndex},{lastMove.RowIndex}) has backward diagonal: {count}");
            return count == FourInARow;
        }

        /// <summary>
        /// Gets the integer array of the game board.
        /// </summary>
        /// <returns>Game board.</returns>
        public int[,] GetBoard()
        {
            return _boardGrid.Clone() as int[,];
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

        /// <summary>
        /// Create a duplicate of this board.
        /// </summary>
        /// <returns>Cloned board.</returns>
        public IBoard Clone()
        {
            Board board = new Board(ColumnSize, RowSize);
            board.SetBoardGrid((int[,])_boardGrid.Clone());
            return board;
        }

        /// <summary>
        /// Set board grid.
        /// </summary>
        /// <param name="boardGrid">Board grid to set.</param>
        private void SetBoardGrid(int[,] boardGrid)
        {
            _boardGrid = boardGrid;
        }
    }
}

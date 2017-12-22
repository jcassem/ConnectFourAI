using ConnectFour.Exceptions;
using System;

namespace ConnectFour
{
    /// <summary>
    /// Connect four game board.
    /// </summary>
    class Board : IBoard
    {
        const int FOUR_IN_A_ROW = 4;

        const int DEFAULT_BOARD_VALUE = 0;

        private int[,] BoardGrid { get; }

        public int ColumnSize { get; }

        public int RowSize { get; }

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
        public void AddPiece(int gamePiece, int column)
        {
            if (IsColumnFull(column))
            {
                throw new BoardColumnFullException($"Column index: {column}");
            }

            if(gamePiece == DEFAULT_BOARD_VALUE)
            {
                throw new AddDefaultValueAsGamePieceException();
            }

            for(int i=0; i<RowSize; i++)
            {
                if(BoardGrid[column,i] == DEFAULT_BOARD_VALUE)
                {
                    BoardGrid[column, i] = gamePiece;
                    break;
                }
            }
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
        public bool IsBoardFull()
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
                if (BoardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                {
                    count++;
                }
                columnIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going left
                columnIndex = lastMove.ColumnIndex - 1;
                while (columnIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (BoardGrid[columnIndex, lastMove.RowIndex].Equals(lastPlayedGamePiece))
                    {
                        count++;
                    }
                    columnIndex--;
                }
            }

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
                if (BoardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    count++;
                }
                rowIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going downwards
                rowIndex = lastMove.RowIndex - 1;
                while (rowIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (BoardGrid[lastMove.ColumnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        count++;
                    }
                    rowIndex--;
                }
            }

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
                if (BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    count++;
                }
                rowIndex++;
                columnIndex++;
            }

            if (count != FOUR_IN_A_ROW)
            {
                // Check run going down to the left
                rowIndex = lastMove.RowIndex - 1;
                columnIndex = lastMove.ColumnIndex - 1;
                while (rowIndex <= 0 && columnIndex >= 0 && count < FOUR_IN_A_ROW)
                {
                    if (BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        count++;
                    }
                    rowIndex--;
                    columnIndex--;
                }
            }

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
                if (BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                {
                    count++;
                }
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
                    if (BoardGrid[columnIndex, rowIndex].Equals(lastPlayedGamePiece))
                    {
                        count++;
                    }
                    rowIndex--;
                    columnIndex++;
                }
            }

            return count == FOUR_IN_A_ROW;
        }
        
        /// <summary>
        /// String representation of the game board.
        /// </summary>
        /// <returns>Game board string.</returns>
        public override string ToString()
        {
            string printedBoard = "";
            string printedRow;

            for (int col = 0; col < ColumnSize; col++)
            {
                printedRow = "| ";
                for (int row = 0; row < RowSize; row++)
                {
                    printedRow += BoardGrid[col, row] == 0 ? "   | " : BoardGrid[col, row].ToString() + " | ";
                }
                printedBoard += printedRow + "\n" + new String('-', printedRow.Length - 1) + "\n";
            }

            return printedBoard;
        }
    }
}

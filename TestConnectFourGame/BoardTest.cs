using ConnectFour;
using ConnectFourGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConnectFourGame
{
    /// <summary>
    /// Tests for Board (not four in a row checks).
    /// </summary>
    [TestClass]
    public class BoardTest
    {
        /// <summary>
        /// Test the get column count check works.
        /// </summary>
        [TestMethod]
        public void ColumnCountTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            Assert.IsTrue(board.GetColumnCount() == BoardCreator.BOARD_COLUMNS);
        }

        /// <summary>
        /// Test the get row count check works.
        /// </summary>
        [TestMethod]
        public void RowCountTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            Assert.IsTrue(board.GetRowCount() == BoardCreator.BOARD_ROWS);
        }

        /// <summary>
        /// Test check to see if a column is full works when the board column is full.
        /// </summary>
        [TestMethod]
        public void ColumnIsFullTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            var column = 0;

            for (int row = 0; row < BoardCreator.BOARD_ROWS; row++)
            {
                board.AddPiece(new GameMove(BoardCreator.PLAYER_ONE_GAME_PIECE, column));
            }

            Assert.IsTrue(board.IsColumnFull(column));
        }

        /// <summary>
        /// Test check to see if a column is full works when the board column is not full.
        /// </summary>
        [TestMethod]
        public void ColumnIsNotFullTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            var column = 0;

            for (int row = 0; row < BoardCreator.BOARD_ROWS - 1; row++)
            {
                board.AddPiece(new GameMove(BoardCreator.PLAYER_ONE_GAME_PIECE, column));
            }

            Assert.IsFalse(board.IsColumnFull(column));
        }

        /// <summary>
        /// Test board is full check works.
        /// </summary>
        [TestMethod]
        public void BoardIsFullTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            for (int col = 0; col < BoardCreator.BOARD_COLUMNS; col++)
            {
                for (int row = 0; row < BoardCreator.BOARD_ROWS; row++)
                {
                    board.AddPiece(new GameMove(BoardCreator.PLAYER_ONE_GAME_PIECE, col));
                }
            }
            Assert.IsTrue(board.IsFull());
        }

        /// <summary>
        /// Test board is full check works when board isn't full.
        /// </summary>
        [TestMethod]
        public void BoardIsNotFullTest()
        {
            IBoard board = new Board(BoardCreator.BOARD_COLUMNS, BoardCreator.BOARD_ROWS);
            for (int col = 0; col < BoardCreator.BOARD_COLUMNS; col++)
            {
                for (int row = 0; row < BoardCreator.BOARD_ROWS - 1; row++)
                {
                    board.AddPiece(new GameMove(BoardCreator.PLAYER_ONE_GAME_PIECE, col));
                }
            }
            Assert.IsFalse(board.IsFull());
        }
    }
}

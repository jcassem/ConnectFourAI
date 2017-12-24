using ConnectFourGame;
using ConnectFourGame.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConnectFourGame.Utils;

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
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            Assert.IsTrue(board.GetColumnCount() == BoardCreator.BoardColumns);
        }

        /// <summary>
        /// Test the get row count check works.
        /// </summary>
        [TestMethod]
        public void RowCountTest()
        {
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            Assert.IsTrue(board.GetRowCount() == BoardCreator.BoardRows);
        }

        /// <summary>
        /// Test check to see if a column is full works when the board column is full.
        /// </summary>
        [TestMethod]
        public void ColumnIsFullTest()
        {
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            var column = 0;

            for (int row = 0; row < BoardCreator.BoardRows; row++)
            {
                board.AddPiece(new GameMove(BoardCreator.PlayerOneGamePiece, column));
            }

            Assert.IsTrue(board.IsColumnFull(column));
        }

        /// <summary>
        /// Test check to see if a column is full works when the board column is not full.
        /// </summary>
        [TestMethod]
        public void ColumnIsNotFullTest()
        {
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            var column = 0;

            for (int row = 0; row < BoardCreator.BoardRows - 1; row++)
            {
                board.AddPiece(new GameMove(BoardCreator.PlayerOneGamePiece, column));
            }

            Assert.IsFalse(board.IsColumnFull(column));
        }

        /// <summary>
        /// Test board is full check works.
        /// </summary>
        [TestMethod]
        public void BoardIsFullTest()
        {
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            for (int col = 0; col < BoardCreator.BoardColumns; col++)
            {
                for (int row = 0; row < BoardCreator.BoardRows; row++)
                {
                    board.AddPiece(new GameMove(BoardCreator.PlayerOneGamePiece, col));
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
            IBoard board = new Board(BoardCreator.BoardColumns, BoardCreator.BoardRows);
            for (int col = 0; col < BoardCreator.BoardColumns; col++)
            {
                for (int row = 0; row < BoardCreator.BoardRows - 1; row++)
                {
                    board.AddPiece(new GameMove(BoardCreator.PlayerOneGamePiece, col));
                }
            }
            Assert.IsFalse(board.IsFull());
        }
    }
}

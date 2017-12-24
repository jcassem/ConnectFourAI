using ConnectFourGame;
using ConnectFourGame.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConnectFourGame.Utils;

namespace TestConnectFourGame
{
    /// <summary>
    /// Tests related to checking for four game pieces in a row.
    /// </summary>
    [TestClass]
    public class ConnectFourCheckTest
    {
        public const int ConnectFourLineLength = 4;

        /// <summary>
        /// Check for horizontal connect four.
        /// </summary>
        [TestMethod]
        public void HorizonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddHorizontalLineToBoard(ConnectFourLineLength, board);
            
            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for vertical connect four.
        /// </summary>
        [TestMethod]
        public void VerticalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddVerticalLineToBoard(ConnectFourLineLength, board);

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for forward diagnonal connect four.
        /// </summary>
        [TestMethod]
        public void ForwardDiagonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddForwardDiagonalLineToBoard(ConnectFourLineLength, board);
            
            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for backward diagonal connect four.
        /// </summary>
        [TestMethod]
        public void BackwardDiagonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddBackwardDiagonalLineToBoard(ConnectFourLineLength, board);

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }
    }
}

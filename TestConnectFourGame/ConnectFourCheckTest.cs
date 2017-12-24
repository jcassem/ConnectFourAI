using ConnectFour;
using ConnectFourGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConnectFourGame
{
    /// <summary>
    /// Tests related to checking for four game pieces in a row.
    /// </summary>
    [TestClass]
    public class ConnectFourCheckTest
    {
        public const int CONNECT_FOUR_LINE_LENGTH = 4;

        /// <summary>
        /// Check for horizontal connect four.
        /// </summary>
        [TestMethod]
        public void HorizonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddHorizontalLineToBoard(CONNECT_FOUR_LINE_LENGTH, board);
            
            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for vertical connect four.
        /// </summary>
        [TestMethod]
        public void VerticalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddVerticalLineToBoard(CONNECT_FOUR_LINE_LENGTH, board);

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for forward diagnonal connect four.
        /// </summary>
        [TestMethod]
        public void ForwardDiagonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddForwardDiagonalLineToBoard(CONNECT_FOUR_LINE_LENGTH, board);
            
            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for backward diagonal connect four.
        /// </summary>
        [TestMethod]
        public void BackwardDiagonalFourTest()
        {
            IBoard board = BoardCreator.GetBlankBoard();

            Point lastMove = BoardCreator.AddBackwardDiagonalLineToBoard(CONNECT_FOUR_LINE_LENGTH, board);

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }
    }
}

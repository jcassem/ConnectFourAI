using ConnectFourGame.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConnectFourGame.Utils;

namespace TestConnectFourGame
{
    /// <summary>
    /// Tests related to board analytics.
    /// </summary>
    [TestClass]
    public class BoardAnalyticsTest
    {
        private const int NumberOfPiecesInALine = 3;

        /// <summary>
        /// Check for horizontal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfHorizontalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithHorizontalLine(NumberOfPiecesInALine);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NumberOfPiecesInALine, BoardCreator.PlayerOneGamePiece, board);

            Assert.AreEqual(numberOfRuns, 1);
        }
        
        /// <summary>
        /// Check for vertical connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfVerticalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithVerticalLine(NumberOfPiecesInALine);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NumberOfPiecesInALine, BoardCreator.PlayerOneGamePiece, board);

            Assert.AreEqual(numberOfRuns, 1);
        }

        /// <summary>
        /// Check for forward diagnonal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfForwardDiagonalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithForwardDiagonalLine(NumberOfPiecesInALine);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NumberOfPiecesInALine, BoardCreator.PlayerOneGamePiece, board);

            Assert.AreEqual(numberOfRuns, 1);
        }

        /// <summary>
        /// Check for backward diagonal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfBackwardDiagonalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithBackwardDiagonalLine(NumberOfPiecesInALine);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NumberOfPiecesInALine, BoardCreator.PlayerOneGamePiece, board);

            Assert.AreEqual(numberOfRuns, 1);
        }
    }
}

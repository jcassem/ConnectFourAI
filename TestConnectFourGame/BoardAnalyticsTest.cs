using ConnectFour;
using ConnectFourGame.Board;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestConnectFourGame
{
    /// <summary>
    /// Tests related to board analytics.
    /// </summary>
    [TestClass]
    public class BoardAnalyticsTest
    {
        private const int NUMBER_OF_PIECES_IN_A_LINE = 3;

        /// <summary>
        /// Check for horizontal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfHorizontalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithHorizontalLine(NUMBER_OF_PIECES_IN_A_LINE);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NUMBER_OF_PIECES_IN_A_LINE, BoardCreator.PLAYER_ONE_GAME_PIECE, board);

            Assert.AreEqual(numberOfRuns, 1);
        }
        
        /// <summary>
        /// Check for vertical connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfVerticalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithVerticalLine(NUMBER_OF_PIECES_IN_A_LINE);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NUMBER_OF_PIECES_IN_A_LINE, BoardCreator.PLAYER_ONE_GAME_PIECE, board);

            Assert.AreEqual(numberOfRuns, 1);
        }

        /// <summary>
        /// Check for forward diagnonal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfForwardDiagonalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithForwardDiagonalLine(NUMBER_OF_PIECES_IN_A_LINE);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NUMBER_OF_PIECES_IN_A_LINE, BoardCreator.PLAYER_ONE_GAME_PIECE, board);

            Assert.AreEqual(numberOfRuns, 1);
        }

        /// <summary>
        /// Check for backward diagonal connect four.
        /// </summary>
        [TestMethod]
        public void CountNumberOfBackwardDiagonalRunsTest()
        {
            IBoard board = BoardCreator.GetBoardWithBackwardDiagonalLine(NUMBER_OF_PIECES_IN_A_LINE);

            IBoardAnalytics boardAnalytics = new BoardAnalytics();
            int numberOfRuns = boardAnalytics.NumberOfPiecesInARowOnBoard(NUMBER_OF_PIECES_IN_A_LINE, BoardCreator.PLAYER_ONE_GAME_PIECE, board);

            Assert.AreEqual(numberOfRuns, 1);
        }
    }
}

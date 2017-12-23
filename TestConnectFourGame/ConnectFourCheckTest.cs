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
        /// <summary>
        /// Check for horizontal connect four.
        /// </summary>
        [TestMethod]
        public void HorizonalFourTest()
        {
            IBoard board = new Board(BoardTest.BOARD_COLUMNS, BoardTest.BOARD_ROWS);

            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 2));
            Point lastMove = board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 3));

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for vertical connect four.
        /// </summary>
        [TestMethod]
        public void VerticalFourTest()
        {
            IBoard board = new Board(BoardTest.BOARD_COLUMNS, BoardTest.BOARD_ROWS);

            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            Point lastMove = board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for forward diagnonal connect four.
        /// </summary>
        [TestMethod]
        public void ForwardDiagonalFourTest()
        {
            IBoard board = new Board(BoardTest.BOARD_COLUMNS, BoardTest.BOARD_ROWS);

            // Add opponent entries to prep for a diagnonal entry
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 2));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 2));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 3));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 3));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 3));

            // Add connect four diagonal
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 2));
            Point lastMove = board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 3));

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }

        /// <summary>
        /// Check for backward diagonal connect four.
        /// </summary>
        [TestMethod]
        public void BackwardDiagonalFourTest()
        {
            IBoard board = new Board(BoardTest.BOARD_COLUMNS, BoardTest.BOARD_ROWS);

            // Add opponent entries to prep for a diagnonal entry
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_TWO_GAME_PIECE, 2));

            // Add connect four diagonal
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 0));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 1));
            board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 2));
            Point lastMove = board.AddPiece(new GameMove(BoardTest.PLAYER_ONE_GAME_PIECE, 3));

            Assert.IsTrue(board.HasConnectFour(lastMove));
        }
    }
}

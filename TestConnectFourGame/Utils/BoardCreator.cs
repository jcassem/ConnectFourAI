using ConnectFour;
using ConnectFourGame;

namespace TestConnectFourGame
{
    class BoardCreator
    {
        public const int BOARD_COLUMNS = 7;
        public const int BOARD_ROWS = 6;

        public const int PLAYER_ONE_GAME_PIECE = 1;
        public const int PLAYER_TWO_GAME_PIECE = 2;

        /// <summary>
        /// Returns a blank game board.
        /// </summary>
        /// <returns>Blank game board.</returns>
        public static IBoard GetBlankBoard()
        {
            return new Board(BOARD_COLUMNS, BOARD_ROWS);
        }

        /// <summary>
        /// Creates and returns a game board with a run of game pieces horizontally added to it.
        /// </summary>
        /// <param name="lineLength">Number of game pieces ina line.</param>
        /// <returns>Created board.</returns>
        public static IBoard GetBoardWithHorizontalLine(int lineLength)
        {
            IBoard board = new Board(BOARD_COLUMNS, BOARD_ROWS);

            AddHorizontalLineToBoard(lineLength, board);

            return board;
        }

        /// <summary>
        /// Adds a horizontal line of a specified length to the provided board.
        /// </summary>
        /// <param name="lineLength">Length of game pieces to add in a line.</param>
        /// <param name="board">Board to add game pieces to.</param>
        /// <returns></returns>
        public static Point AddHorizontalLineToBoard(int lineLength, IBoard board)
        {
            Point lastMove = null;
            
            for (int i = 0; i < lineLength; i++)
            {
                lastMove = board.AddPiece(new GameMove(PLAYER_ONE_GAME_PIECE, i));
            }

            return lastMove;
        }

        /// <summary>
        /// Creates and returns a game board with a run of game pieces vertically added to it.
        /// </summary>
        /// <param name="lineLength">Number of game pieces ina line.</param>
        /// <returns>Created board.</returns>
        public static IBoard GetBoardWithVerticalLine(int lineLength)
        {
            IBoard board = new Board(BOARD_COLUMNS, BOARD_ROWS);

            AddVerticalLineToBoard(lineLength, board);

            return board;
        }
        
        /// <summary>
        /// Adds a vertical line of a specified length to the provided board.
        /// </summary>
        /// <param name="lineLength">Length of game pieces to add in a line.</param>
        /// <param name="board">Board to add game pieces to.</param>
        /// <returns></returns>
        public static Point AddVerticalLineToBoard(int lineLength, IBoard board)
        {
            Point lastMove = null;
            
            for (int i = 0; i < lineLength; i++)
            {
                lastMove = board.AddPiece(new GameMove(PLAYER_ONE_GAME_PIECE, 0));
            }

            return lastMove;
        }

        /// <summary>
        /// Creates and returns a game board with a run of game pieces added in a forward diagonal.
        /// </summary>
        /// <param name="lineLength">Number of game pieces ina line.</param>
        /// <returns>Created board.</returns>
        public static IBoard GetBoardWithForwardDiagonalLine(int lineLength)
        {
            IBoard board = new Board(BOARD_COLUMNS, BOARD_ROWS);

            AddForwardDiagonalLineToBoard(lineLength, board);

            return board;
        }

        /// <summary>
        /// Adds a forward diagonal line of a specified length to the provided board.
        /// </summary>
        /// <param name="lineLength">Length of game pieces to add in a line.</param>
        /// <param name="board">Board to add game pieces to.</param>
        /// <returns></returns>
        public static Point AddForwardDiagonalLineToBoard(int lineLength, IBoard board)
        {
            Point lastMove = null;

            // Add opponents pieces to setup for main run
            for (int i = 1; i < lineLength; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    board.AddPiece(new GameMove(PLAYER_TWO_GAME_PIECE, i));
                }
            }

            // Add first player pieces to form requested line run
            for (int i = 0; i < lineLength; i++)
            {
                lastMove = board.AddPiece(new GameMove(PLAYER_ONE_GAME_PIECE, i));
            }

            return lastMove;
        }

        /// <summary>
        /// Creates and returns a game board with a run of game pieces added in a backward diagonal.
        /// </summary>
        /// <param name="lineLength">Number of game pieces ina line.</param>
        /// <returns>Created board.</returns>
        public static IBoard GetBoardWithBackwardDiagonalLine(int lineLength)
        {
            IBoard board = new Board(BOARD_COLUMNS, BOARD_ROWS);

            AddBackwardDiagonalLineToBoard(lineLength, board);

            return board;
        }

        /// <summary>
        /// Adds a backward diagonal line of a specified length to the provided board.
        /// </summary>
        /// <param name="lineLength">Length of game pieces to add in a line.</param>
        /// <param name="board">Board to add game pieces to.</param>
        /// <returns></returns>
        public static Point AddBackwardDiagonalLineToBoard(int lineLength, IBoard board)
        {
            Point lastMove = null; 

            // Add opponents pieces to setup for main run
            for (int i = 0; i > lineLength; i++)
            {
                for (int j = 0; j < lineLength - i; j++)
                {
                    board.AddPiece(new GameMove(PLAYER_TWO_GAME_PIECE, i));
                }
            }

            // Add first player pieces to form requested line run
            for (int i = 0; i < lineLength; i++)
            {
                lastMove = board.AddPiece(new GameMove(PLAYER_ONE_GAME_PIECE, i));
            }

            return lastMove;
        }
    }
}

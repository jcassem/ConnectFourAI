namespace ConnectFour
{
    /// <summary>
    /// Connect four game.
    /// </summary>
    class ConnectFourGame
    {
        const int DEFAULT_BOARD_COLUMNS = 7;
        const int DEFAULT_BOARD_ROWS = 6;

        const int PLAYER_ONE_GAME_PIECE = 1;
        const int PLAYER_TWO_GAME_PIECE = 2;
        
        private Player _playerOne;
        private Player _playerTwo;
        private Board _board;

        private bool _playerOneNext;
        private Point _lastMove;

        /// <summary>
        /// Constructor to set up connect four game.
        /// </summary>
        public ConnectFourGame()
        {
            _board = new Board(DEFAULT_BOARD_COLUMNS, DEFAULT_BOARD_ROWS);
            _playerOne = new Player("Player One", PLAYER_ONE_GAME_PIECE);
            _playerTwo = new Player("Player Two", PLAYER_TWO_GAME_PIECE);
            _playerOneNext = true;
        }

        /// <summary>
        /// Returns string representation of game board.
        /// </summary>
        /// <returns>String representation of game board.</returns>
        public string GetPrintedBoard()
        {
            return _board.ToString();
        }

    }
}

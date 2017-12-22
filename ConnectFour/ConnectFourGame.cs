using System;

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
            _playerOne = new RandomPlayer("Player One", PLAYER_ONE_GAME_PIECE);
            _playerTwo = new RandomPlayer("Player Two", PLAYER_TWO_GAME_PIECE);
            _playerOneNext = true;
        }

        public void PlayNextMove()
        {
            if (_playerOneNext)
            {
                _lastMove = _playerOne.MakeMove(_board);
            }
            else
            {
                _lastMove =  _playerTwo.MakeMove(_board);
            }

            _playerOneNext = !_playerOneNext;
        }

        public bool BoardIsFull()
        {
            return _board.IsFull();
        }

        public bool LastMoveWonGame()
        {
            return _board.HasConnectFour(_lastMove);
        }

        /// <summary>
        /// Returns string representation of game board.
        /// </summary>
        /// <returns>String representation of game board.</returns>
        public string GetPrintedBoard()
        {
            string printedBoard = "";
            string printedRow;
            for (int row = _board.GetRowCount() - 1; row >= 0; row--)
            {
                printedRow = "| ";
                for (int col = 0; col < _board.GetColumnCount(); col++) 
                {
                    printedRow += _board.GetBoard()[col, row] == 0 ? "  | " : _board.GetBoard()[col, row].ToString() + " | ";
                }
                printedBoard += printedRow + "\n" + new String('-', printedRow.Length - 1) + "\n";
            }

            return printedBoard;
        }
    }
}

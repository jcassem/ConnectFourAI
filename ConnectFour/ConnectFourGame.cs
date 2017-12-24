using System;
using ConnectFourGame.Player;

namespace ConnectFourGame
{
    /// <summary>
    /// Connect four game.
    /// </summary>
    public class ConnectFourGame
    {
        private const int DefaultBoardColumns = 7;
        public const int DefaultBoardRows = 6;

        const int PlayerOneGamePiece = 1;
        const int PlayerTwoGamePiece = 2;

        private readonly Player.Player _playerOne;
        private readonly Player.Player _playerTwo;
        private readonly Board.Board _board;

        private bool _playerOneNext;
        private int _moveCount;
        private Point _lastMove;

        /// <summary>
        /// Constructor to set up connect four game.
        /// </summary>
        public ConnectFourGame()
        {
            _board = new Board.Board(DefaultBoardColumns, DefaultBoardRows);
            _playerOne = new RandomPlayer("Player One", PlayerOneGamePiece);
            _playerTwo = new RandomPlayer("Player Two", PlayerTwoGamePiece);
            _playerOneNext = true;
            _moveCount = 0;
        }

        /// <summary>
        /// Play automated games next move.
        /// </summary>
        public void PlayNextMove()
        {
            if (_playerOneNext)
            {
                _lastMove = _playerOne.MakeMove(_board);
            }
            else
            {
                _lastMove = _playerTwo.MakeMove(_board);
            }

            _playerOneNext = !_playerOneNext;
            _moveCount++;
        }

        /// <summary>
        /// Check if the game board is full of game pieces.
        /// </summary>
        /// <returns>Whether the game board is full.</returns>
        public bool BoardIsFull()
        {
            return _board.IsFull();
        }

        /// <summary>
        /// Check if the last move resulted in a connect four.
        /// </summary>
        /// <returns>Board has connect four.</returns>
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
            string printedRow = "";

            for (int row = _board.GetRowCount() - 1; row >= 0; row--)
            {
                printedRow = $"{row}: > ";
                for (int col = 0; col < _board.GetColumnCount(); col++)
                {
                    var gamePiece = _board.GetBoard()[col, row].Equals(PlayerOneGamePiece) ? "X"
                        : _board.GetBoard()[col, row].Equals(PlayerTwoGamePiece) ? "O"
                        : " ";
                    printedRow += gamePiece + " | ";
                }
                printedBoard += printedRow + "\n   > " + new String('-', printedRow.Length - 5) + "\n";
            }

            printedBoard += "    ^" + new String('^', printedRow.Length - 5) + "\n";
            printedBoard += "     ";
            for (int col = 0; col < _board.GetColumnCount(); col++)
            {
                printedBoard += $"{col} | ";
            }
            printedBoard += "\n";

            return printedBoard;
        }
    }
}

using System;
using System.Threading;

namespace ConnectFourGame
{
    /// <summary>
    /// Connect four game.
    /// </summary>
    public class ConnectFourGame
    {
        private const int DefaultBoardColumns = 7;
        public const int DefaultBoardRows = 6;

        public const int PlayerOneGamePiece = 1;
        public const int PlayerTwoGamePiece = 2;

        private readonly Player.IPlayer _playerOne;
        private readonly Player.IPlayer _playerTwo;
        private readonly Board.Board _board;

        private bool _playerOneNext;
        private Point _lastMove;

        /// <summary>
        /// Constructor to set up connect four game.
        /// </summary>
        public ConnectFourGame(Player.IPlayer playerOne, Player.IPlayer playerTwo)
        {
            _board = new Board.Board(DefaultBoardColumns, DefaultBoardRows);

            _playerOne = playerOne;
            _playerTwo = playerTwo;

            _playerOneNext = true;
        }

        /// <summary>
        /// Runs the game set up.
        /// </summary>
        /// <param name="displayGame">Print the game board after each players move.</param>
        public void PlayGame(bool displayGame = false)
        {
            bool gameOver = false;
            while (!gameOver)
            {
                // Console.Clear();
                PlayNextMove();

                if (_board.IsFull())
                {
                    gameOver = true;
                    if (displayGame)
                    {
                        Console.WriteLine("Board is full");
                    }
                }
                else if (_board.HasConnectFour(_lastMove))
                {
                    gameOver = true;
                    if (displayGame)
                    {
                        Console.WriteLine("Player wins");
                    }
                }

                if (displayGame)
                {
                    Console.WriteLine(GetPrintedBoard());
                    Thread.Sleep(500);
                }
            }
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
        }

        /// <summary>
        /// Returns string representation of game board.
        /// </summary>
        /// <returns>String representation of game board.</returns>
        private string GetPrintedBoard()
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

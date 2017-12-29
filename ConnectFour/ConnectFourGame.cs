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
        public readonly Board.Board Board;

        private bool _playerOneNext;
        private Point _lastMove;

        public WinningPlayer Winner = WinningPlayer.NoWinners;

        /// <summary>
        /// Winning player options.
        /// </summary>
        public enum WinningPlayer
        {
            PlayerOneWins,
            PlayerTwoWins,
            NoWinners
        }

        /// <summary>
        /// Constructor to set up connect four game.
        /// </summary>
        public ConnectFourGame(Player.IPlayer playerOne, Player.IPlayer playerTwo)
        {
            Board = new Board.Board(DefaultBoardColumns, DefaultBoardRows);

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

                if (Board.IsFull())
                {
                    gameOver = true;
                    if (displayGame)
                    {
                        Console.WriteLine("Board is full");
                    }
                }
                else if (Board.HasConnectFour(_lastMove))
                {
                    gameOver = true;
                    Winner = _playerOneNext ? WinningPlayer.PlayerTwoWins : WinningPlayer.PlayerOneWins;

                    if (displayGame)
                    {
                        var winningPlayer = Winner == WinningPlayer.PlayerOneWins ? "Player One" : "Player Two";
                        Console.WriteLine($"{winningPlayer} wins");
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
            _lastMove = _playerOneNext ? _playerOne.MakeMove(Board) : _playerTwo.MakeMove(Board);
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

            for (int row = Board.GetRowCount() - 1; row >= 0; row--)
            {
                printedRow = $"{row}: > ";
                for (int col = 0; col < Board.GetColumnCount(); col++)
                {
                    var gamePiece = Board.GetBoard()[col, row].Equals(PlayerOneGamePiece) ? "X"
                        : Board.GetBoard()[col, row].Equals(PlayerTwoGamePiece) ? "O"
                        : " ";
                    printedRow += gamePiece + " | ";
                }
                printedBoard += printedRow + "\n   > " + new String('-', printedRow.Length - 5) + "\n";
            }

            printedBoard += "    ^" + new String('^', printedRow.Length - 5) + "\n";
            printedBoard += "     ";
            for (int col = 0; col < Board.GetColumnCount(); col++)
            {
                printedBoard += $"{col} | ";
            }
            printedBoard += "\n";

            return printedBoard;
        }
    }
}

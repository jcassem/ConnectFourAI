using System;
using System.Threading;
using ConnectFourGame.Player;

namespace ConnectFourGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player.Player playerOne = new AiPlayer("Player One", ConnectFourGame.PlayerOneGamePiece);
            Player.Player playerTwo = new AiPlayer("Player Two", ConnectFourGame.PlayerTwoGamePiece);

            ConnectFourGame game = new ConnectFourGame(playerOne, playerTwo);
            Console.WriteLine(game.GetPrintedBoard());

            Console.WriteLine("Starting game:");
            bool gameOver = false;

            while (!gameOver)
            {
                // Console.Clear();
                game.PlayNextMove();

                if (game.BoardIsFull())
                {
                    Console.WriteLine("Board is full");
                    gameOver = true;
                }
                else if (game.LastMoveWonGame())
                {
                    Console.WriteLine("Player wins");
                    gameOver = true;
                }

                Console.WriteLine(game.GetPrintedBoard());
                Thread.Sleep(500);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
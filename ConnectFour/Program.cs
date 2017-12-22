using System;
using System.Threading;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            // sConsole.WriteLine("Press any key to start game...");
            // Console.ReadKey();

            ConnectFourGame game = new ConnectFourGame();
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
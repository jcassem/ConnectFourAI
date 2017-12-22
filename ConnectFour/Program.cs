using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectFourGame game = new ConnectFourGame();
            Console.WriteLine(game.GetPrintedBoard());
            Console.ReadKey();
        }
    }
}
using ConnectFourGame.Player;
using System;

namespace ConnectFourGame
{
    class RandomGame
    {
        static void Main(string[] args)
        {
            IPlayer playerOne = new RandomPlayer(ConnectFourGame.PlayerOneGamePiece);
            IPlayer playerTwo = new RandomPlayer(ConnectFourGame.PlayerTwoGamePiece);

            ConnectFourGame game = new ConnectFourGame(playerOne, playerTwo);
            game.PlayGame(true);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
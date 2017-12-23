using ConnectFour.Exceptions;
using System;

namespace ConnectFour
{
    /// <summary>
    /// Connect four player - picks where to go randomly.
    /// </summary>
    public class RandomPlayer : Player
    {
        /// <summary>
        /// Random Player constructor.
        /// </summary>
        /// <param name="Name">Players name.</param>
        /// <param name="GamePiece">Game piece.</param>
        public RandomPlayer(string Name, int GamePiece) : base(Name, GamePiece)
        {
        }

        /// <summary>
        /// Apply a game piece to a random column on the board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public override Point MakeMove(IBoard board)
        {
            if (board.IsFull())
            {
                throw new BoardFullException();
            }

            Random rndm = new Random();
            var nextColumn = rndm.Next(0, board.GetColumnCount());

            while (board.IsColumnFull(nextColumn))
            {
                nextColumn++;
                if (nextColumn >= board.GetColumnCount())
                {
                    nextColumn = 0;
                }
            }

            return board.AddPiece(GamePiece, nextColumn);
        }
    }
}

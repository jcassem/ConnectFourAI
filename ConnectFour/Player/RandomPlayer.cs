using System;
using ConnectFourGame.Board;
using ConnectFourGame.Exceptions;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Connect four player - picks where to go randomly.
    /// </summary>
    public class RandomPlayer : Player
    {
        /// <summary>
        /// Random Player constructor.
        /// </summary>
        /// <param name="gamePiece">Game piece.</param>
        public RandomPlayer(int gamePiece) : base(gamePiece)
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

            return board.AddPiece(new GameMove(GamePiece, nextColumn));
        }
    }
}

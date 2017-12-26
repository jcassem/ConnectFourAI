using ConnectFourGame.Board;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Connect four player.
    /// </summary>
    public abstract class Player
    {
        public string Name { get; }
        public int GamePiece { get; }

        /// <summary>
        /// Player constructor.
        /// </summary>
        /// <param name="gamePiece">Players game piece.</param>
        protected Player(int gamePiece)
        {
            Name = "Player " + gamePiece;
            GamePiece = gamePiece;
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public abstract Point MakeMove(IBoard board);
    }
}

using ConnectFourGame.Board;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Connect four player.
    /// </summary>
    public abstract class AbstractPlayer
    {
        public string Name { get; }
        public int GamePiece { get; set; }

        /// <summary>
        /// Player constructor.
        /// </summary>
        /// <param name="gamePiece">Players game piece.</param>
        protected AbstractPlayer(int gamePiece)
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

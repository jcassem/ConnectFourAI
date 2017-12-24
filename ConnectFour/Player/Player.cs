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
        /// <param name="name">Player name.</param>
        /// <param name="gamePiece">Players game piece.</param>
        protected Player(string name, int gamePiece)
        {
            Name = name;
            GamePiece = gamePiece;
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        public abstract Point MakeMove(IBoard board);
    }
}

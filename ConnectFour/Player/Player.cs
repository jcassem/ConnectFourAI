namespace ConnectFour
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
        /// <param name="Name">Player name.</param>
        /// <param name="GamePiece">Players game piece.</param>
        public Player(string Name, int GamePiece)
        {
            this.Name = Name;
            this.GamePiece = GamePiece;
        }

        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        abstract public Point MakeMove(IBoard board);
    }
}

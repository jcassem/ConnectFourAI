namespace ConnectFourGame
{
    /// <summary>
    /// Game Move for connect four.
    /// </summary>
    public class GameMove
    {
        public int GamePiece { get; }

        public int BoardColumn { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="gamePiece">Players game piece for move.</param>
        /// <param name="boardColumn">Column on board for the move.</param>
        public GameMove(int gamePiece, int boardColumn)
        {
            GamePiece = gamePiece;
            BoardColumn = boardColumn;
        }
    }
}

using ConnectFourGame.Board;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Connect four player.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Apply a game piece to board.
        /// </summary>
        /// <param name="board">Connect four game board.</param>
        Point MakeMove(IBoard board);
    }
}

using ConnectFourGame.Board;

namespace ConnectFourGame.Player
{
    /// <summary>
    /// Basic ground work for an AI connect four player.
    /// </summary>
    public interface IAiPlayer
    {
        /// <summary>
        /// Analyse move options and return the column index this player thinks will be best.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Column index for next move.</returns>
        int PickNextMoveColumn(IBoard board);

        /// <summary>
        /// Get the players self defined score of a column index as its next move.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <param name="columnIndex">Column index.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        long GetColumnScore(IBoard board, int columnIndex);
    }
}

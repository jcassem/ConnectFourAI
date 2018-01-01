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
        /// Get the column with the highest score.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        int GetHighestScoringColumnIndex(IBoard board);

        /// <summary>
        /// Get the players self defined score of the current state of the board.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <returns>Score of the board.</returns>
        long GetBoardScore(IBoard board);

        /// <summary>
        /// Get the players self defined score of a column index as its next move.
        /// </summary>
        /// <param name="board">Game board.</param>
        /// <param name="columnIndexForPotentialMove">Column index for next potential move.</param>
        /// <returns>Score of the column choice as players next move.</returns>
        long GetColumnScoreAfterPotentialMove(IBoard board, int columnIndexForPotentialMove);

        /// <summary>
        /// Returns score player received from its last match.
        /// </summary>
        /// <returns>Last game score.</returns>
        long GetLastGameScore();
    }
}

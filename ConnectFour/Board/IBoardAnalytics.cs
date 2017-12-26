namespace ConnectFourGame.Board
{
    /// <summary>
    /// Tools to gather statistics and analysis on the current and potential state of a Connect four game board.
    /// </summary>
    public interface IBoardAnalytics
    {
        /// <summary>
        /// Counts the number of runs of game pieces in a row on a board.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="gamePiece">Game piece to look for.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs on a board.</returns>
        int NumberOfPiecesInARowOnBoard(int piecesInARow, int gamePiece, IBoard board);

        /// <summary>
        /// Counts the number of runs of game pieces in a row on a board after a potential move.
        /// </summary>
        /// <param name="piecesInARow">Number of pieces in a row to count.</param>
        /// <param name="potentialMove">Potential move to do before running analytics.</param>
        /// <param name="board">Game board to check.</param>
        /// <returns>Number of connect Xs on a board.</returns>
        int NumberOfPiecesInARowOnBoardFromPotentialMove(int piecesInARow, GameMove potentialMove, IBoard board);
    }
}

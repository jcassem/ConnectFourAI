namespace ConnectFour
{
    /// <summary>
    /// Interface for a Connect four game board.
    /// </summary>
    interface IBoard
    {
        /// <summary>
        /// Checks if board has four of the same game pieces in a row.
        /// Either horizontally, vertically or diagonally.
        /// </summary>
        /// <param name="lastMove">Last move in the game (for efficient processing).</param>
        /// <returns>Whether game board has gour of the same game pieces in a row.</returns>
        bool HasConnectFour(Point lastMove);

        /// <summary>
        /// Adds a players game piece representation to the board.
        /// </summary>
        /// <param name="gamePiece">Game piece to add.</param>
        /// <param name="column">Column on the board to add it to.</param>
        Point AddPiece(int gamePiece, int column);
        
        /// <summary>
        /// Checks if a column on the game board is full of game pieces.
        /// </summary>
        /// <param name="column">Column on game board to check.</param>
        /// <returns>Whether column on game board is full.</returns>
        bool IsColumnFull(int column);

        /// <summary>
        /// Checks if the whole board is full of game pieces.
        /// </summary>
        /// <returns>Whether the board is full of game pieces.</returns>
        bool IsFull();

        /// <summary>
        /// Gets the integer array of the game board.
        /// </summary>
        /// <returns>Game board.</returns>
        int[,] GetBoard();

        /// <summary>
        /// Returns number of columns in the board.
        /// </summary>
        /// <returns>Number of columns in board.</returns>
        int GetColumnCount();

        /// <summary>
        /// Returns number of rows in the board.
        /// </summary>
        /// <returns>Number of rows in board.</returns>
        int GetRowCount();
    }
}

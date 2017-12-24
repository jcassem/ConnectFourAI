namespace ConnectFourGame
{
    /// <summary>
    /// Column, Row co-ordinates as a point for the game board.
    /// </summary>
    public class Point
    {
        public int ColumnIndex { get; }
        public int RowIndex { get; }

        /// <summary>
        /// Constructor for game board co-ordinates.
        /// </summary>
        /// <param name="columnIndex">Column index co-ordinate.</param>
        /// <param name="rowIndex">Row index co-ordinate.</param>
        public Point(int columnIndex, int rowIndex)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
        }
    }
}
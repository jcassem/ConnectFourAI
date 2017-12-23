namespace ConnectFour
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
        /// <param name="ColumnIndex">Column index co-ordinate.</param>
        /// <param name="RowIndex">Row index co-ordinate.</param>
        public Point(int ColumnIndex, int RowIndex)
        {
            this.ColumnIndex = ColumnIndex;
            this.RowIndex = RowIndex;
        }
    }
}
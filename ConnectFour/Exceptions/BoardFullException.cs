using System;

namespace ConnectFour.Exceptions
{
    /// <summary>
    /// Exception for the board being full.
    /// </summary>
    class BoardFullException : Exception
    {

        public BoardFullException()
        {
        }

        public BoardFullException (string message)
            : base(message)
        {
        }

        public BoardFullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

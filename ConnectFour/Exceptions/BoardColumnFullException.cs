using System;

namespace ConnectFour.Exceptions
{
    /// <summary>
    /// Exception for a board column being full.
    /// </summary>
    class BoardColumnFullException : Exception
    {
        public BoardColumnFullException()
        {
        }

        public BoardColumnFullException(string message)
            : base(message)
        {
        }

        public BoardColumnFullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

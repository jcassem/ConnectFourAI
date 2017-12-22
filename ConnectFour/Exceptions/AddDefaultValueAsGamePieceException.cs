using System;

namespace ConnectFour.Exceptions
{
    /// <summary>
    /// Exception for an attempt to add the default board value as a game piece.
    /// </summary>
    class AddDefaultValueAsGamePieceException : Exception
    {

        public AddDefaultValueAsGamePieceException()
        {
        }

        public AddDefaultValueAsGamePieceException(string message)
            : base(message)
        {
        }

        public AddDefaultValueAsGamePieceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

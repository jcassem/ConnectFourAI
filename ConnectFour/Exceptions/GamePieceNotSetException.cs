using System;

namespace ConnectFourGame.Exceptions
{
    /// <summary>
    /// Exception for a player not having a game piece.
    /// </summary>
    class GamePieceNotSetException : Exception
    {
        public GamePieceNotSetException()
        {
        }

        public GamePieceNotSetException(string message)
            : base(message)
        {
        }

        public GamePieceNotSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

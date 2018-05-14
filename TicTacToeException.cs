using System;
using System.Runtime.Serialization;

namespace TicTacToe
{
    [Serializable]
    internal class TicTacToeException : Exception
    {
        public TicTacToeException()
        {
        }

        public TicTacToeException(string message) : base(message)
        {
        }

        public TicTacToeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicTacToeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
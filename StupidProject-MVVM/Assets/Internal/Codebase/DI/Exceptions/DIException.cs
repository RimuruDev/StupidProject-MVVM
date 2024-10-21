using System;

namespace AbyssMoth.Internal.Codebase.DI.Exceptions
{
    public sealed class DIException : Exception
    {
        public DIException()
        {
        }

        public DIException(string message) : base(message)
        {
        }

        public DIException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;

namespace AbyssMoth.DI
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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
using System;
using UnityEngine;
using AbyssMoth.Internal.Codebase.DI.Exceptions;

namespace AbyssMoth.Internal.Codebase.DI.Utilities
{
    public static class CrashReporter
    {
        public static void Report(string message, Exception inner = null) => 
            InternalReport(message, inner, isThrow: false);

        public static void ReportThrow(string message, Exception inner = null) => 
            InternalReport(message, inner, isThrow: true);

        private static void InternalReport(string message, Exception inner = null, bool isThrow = true)
        {
            if (isThrow)
            {
                if (inner != null)
                    throw new DIException(message, inner);

                throw new DIException(message);
            }

            Debug.LogException(inner != null ? new DIException(message, inner) : new DIException(message));
        }
    }
}
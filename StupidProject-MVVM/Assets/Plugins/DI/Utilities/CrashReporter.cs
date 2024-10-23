using System;
using UnityEngine;

namespace AbyssMoth.DI
{
    public static class CrashReporter
    {
        public static void Report(string message, Exception inner = null) =>
            InternalReport(message, inner, isThrow: false);

        public static void ReportThrow(string message, Exception inner = null) =>
            InternalReport(message, inner, isThrow: true);

        public static T ReportThrow<T>(string message, Exception inner = null)
        {
            InternalReport(message, inner, isThrow: true);

            return default;
        }

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
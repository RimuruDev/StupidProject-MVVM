using System;
using AbyssMoth.Internal.Codebase.DI.Entytys;
using AbyssMoth.Internal.Codebase.DI.Utilities;

namespace AbyssMoth.Internal.Codebase.DI.Container
{
    public sealed partial class DIContainer
    {
        public DIEntryBase RegisterFactory<T>(Func<DIContainer, T> factory) =>
            RegisterFactory(null, factory);

        public DIEntryBase RegisterFactory<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));

            if (entriesMap.ContainsKey(key))
                CrashReporter.ReportThrow($"Factory with tag {key.Item1} and type {key.Item2.FullName} has already registered!!!");

            var diEntry = new DIEntry<T>(this, factory);

            entriesMap[key] = diEntry;

            return diEntry;
        }

        public void RegisterInstance<T>(T instance) =>
            RegisterInstance(null, instance);

        public void RegisterInstance<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));

            if (entriesMap.ContainsKey(key))
                CrashReporter.ReportThrow($"Instance with tag {key.Item1} and type {key.Item2.FullName} has already registered!!!");

            var diEntry = new DIEntry<T>(instance);

            entriesMap[key] = diEntry;
        }
    }
}
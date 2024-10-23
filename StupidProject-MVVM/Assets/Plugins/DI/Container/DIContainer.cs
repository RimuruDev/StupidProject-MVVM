using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace AbyssMoth.DI
{
    [UsedImplicitly]
    public sealed partial class DIContainer : IDisposable
    {
        private readonly DIContainer parentContainer;
        private readonly Dictionary<(string, Type), DIEntryBase> entriesMap = new();
        private readonly HashSet<(string, Type)> resolutionsCache = new();

        public DIContainer(DIContainer parentContainer = null) =>
            this.parentContainer = parentContainer;

        public void Dispose()
        {
            var entries = entriesMap.Values;

            foreach (var entry in entries)
                entry.Dispose();
        }
    }
}
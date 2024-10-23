namespace AbyssMoth.DI
{
    public sealed partial class DIContainer
    {
        public T Resolve<T>(string tag = null)
        {
            var key = (tag, typeof(T));

            if (resolutionsCache.Contains(key))
                CrashReporter.ReportThrow($"Cyclic dependency for tag {key.tag} and type {key.Item2.FullName}");

            resolutionsCache.Add(key);

            try
            {
                if (entriesMap.TryGetValue(key, out var diEntry))
                    return diEntry.Resolve<T>();

                if (parentContainer != null)
                    return parentContainer.Resolve<T>(tag);
            }
            finally
            {
                resolutionsCache.Remove(key);
            }

            return CrashReporter.ReportThrow<T>($"Couldn't find dependency for tag {tag} and type {key.Item2.FullName}");
        }
    }
}
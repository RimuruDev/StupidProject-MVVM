using static AbyssMoth.Internal.Codebase.DI.Utilities.CrashReporter;

namespace AbyssMoth.Internal.Codebase.DI.Container
{
    public partial class DIContainer
    {
        public T Resolve<T>(string tag = null)
        {
            var key = (tag, typeof(T));

            if (registrations.TryGetValue(key, out var registration))
            {
                if (registration.IsSingleton)
                {
                    if (registration.Instance == null && registration.Factory != null)
                    {
                        registration.Instance = registration.Factory(this);
                    }

                    return (T)registration.Instance;
                }

                return (T)registration.Factory(this);
            }

            if (parentContainer != null)
            {
                return parentContainer.Resolve<T>(tag);
            }

            return ReportThrow<T>($"Couldn't find dependency for tag: {tag} and type key: {key.Item2.FullName}");
        }
    }
}
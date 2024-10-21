using System;
using static AbyssMoth.Internal.Codebase.DI.Utilities.CrashReporter;

namespace AbyssMoth.Internal.Codebase.DI.Container
{
    public partial class DIContainer
    {
        public void RegisterSingleton<T>(Func<DIContainer, T> factory)
        {
            RegisterSingleton(tag: null, factory);
        }

        public void RegisterSingleton<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, isSingleton: true);
        }

        public void RegisterTransient<T>(Func<DIContainer, T> factory)
        {
            RegisterTransient(tag: null, factory);
        }

        public void RegisterTransient<T>(string tag, Func<DIContainer, T> factory)
        {
            var key = (tag, typeof(T));
            Register(key, factory, isSingleton: false);
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(tag: null, instance);
        }

        public void RegisterInstance<T>(string tag, T instance)
        {
            var key = (tag, typeof(T));

            if (registrations.ContainsKey(key))
            {
                ReportThrow($"Factory with tag: {key.Item1} and type {key.Item2.FullName} has already registrations.");
            }

            if (instance == null)
            {
                ReportThrow($"Attempt to register null! Please pass a valid parameter of type {typeof(T)} to {nameof(DIContainer)}.{nameof(RegisterInstance)}.");
            }

            registrations[key] = new DIRegistration
            {
                Instance = instance,
                IsSingleton = true,
            };
        }

        private void Register<T>((string, Type) key, Func<DIContainer, T> factory, bool isSingleton)
        {
            if (registrations.ContainsKey(key))
            {
                ReportThrow($"Factory with tag: {key.Item1} and type {key.Item2.FullName} has already registrations.");
            }

            registrations[key] = new DIRegistration
            {
                Factory = container => factory(container),
                IsSingleton = isSingleton,
            };
        }
    }
}
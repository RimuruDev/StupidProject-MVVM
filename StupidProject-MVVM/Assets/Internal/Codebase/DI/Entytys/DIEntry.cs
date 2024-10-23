using System;
using AbyssMoth.Internal.Codebase.DI.Container;

namespace AbyssMoth.Internal.Codebase.DI.Entytys
{
    public class DIEntry<T> : DIEntryBase
    {
        private Func<DIContainer, T> Factory { get; }
        private T instance;
        private IDisposable disposableInstance;

        public DIEntry(DIContainer container, Func<DIContainer, T> factory) : base(container) =>
            Factory = factory;

        public DIEntry(T value)
        {
            instance = value;

            if (instance is IDisposable disposable)
                disposableInstance = disposable;

            IsSingleton = true;
        }

        public T Resolve()
        {
            if (IsSingleton)
            {
                if (instance == null)
                {
                    instance = Factory(Container);

                    if (instance is IDisposable disposable)
                        disposableInstance = disposable;
                }

                return instance;
            }

            return Factory(Container);
        }

        public override void Dispose() =>
            disposableInstance?.Dispose();
    }
}
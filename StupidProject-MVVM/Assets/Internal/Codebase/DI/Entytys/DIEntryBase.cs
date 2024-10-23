using System;
using AbyssMoth.Internal.Codebase.DI.Container;

namespace AbyssMoth.Internal.Codebase.DI.Entytys
{
    public abstract class DIEntryBase : IDisposable
    {
        protected DIContainer Container { get; }
        protected bool IsSingleton { get; set; }

        protected DIEntryBase() { }

        protected DIEntryBase(DIContainer container) =>
            Container = container;

        public T Resolve<T>() =>
            ((DIEntry<T>)this).Resolve();

        public DIEntryBase AsSingle()
        {
            IsSingleton = true;

            return this;
        }

        public abstract void Dispose();
    }
}
using System;
using AbyssMoth.Internal.Codebase.DI.Container;

namespace AbyssMoth.Internal.Codebase.DI
{
    public class DIRegistration
    {
        public Func<DIContainer, object> Factory { get; set; }
        public bool IsSingleton { get; set; }
        public object Instance { get; set; }
    }
}
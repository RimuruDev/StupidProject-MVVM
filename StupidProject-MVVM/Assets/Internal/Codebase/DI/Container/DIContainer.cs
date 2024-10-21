using System;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace AbyssMoth.Internal.Codebase.DI.Container
{
    [UsedImplicitly]
    public partial class DIContainer
    {
        private readonly DIContainer parentContainer;
        private readonly HashSet<(string, Type)> resolutions = new();
        private readonly Dictionary<(string, Type), DIRegistration> registrations = new();

        public DIContainer(DIContainer parentContainer)
        {
            this.parentContainer = parentContainer;
        }
    }
}
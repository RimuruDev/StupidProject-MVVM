using AbyssMoth.Internal.Codebase.Infrastructure.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public class UIGameplayRootViewModel
    {
        private SomeCommandService someCommandService;

        public UIGameplayRootViewModel(SomeCommandService someCommandService)
        {
            this.someCommandService = someCommandService;
        }
    }
}
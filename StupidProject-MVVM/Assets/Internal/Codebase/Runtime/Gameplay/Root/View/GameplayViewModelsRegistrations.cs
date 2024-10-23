using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer diContainer)
        {
            diContainer.RegisterFactory(c => new WorldGameplayRootViewModel());
            diContainer.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeCommandService>()));
        }
    }
}
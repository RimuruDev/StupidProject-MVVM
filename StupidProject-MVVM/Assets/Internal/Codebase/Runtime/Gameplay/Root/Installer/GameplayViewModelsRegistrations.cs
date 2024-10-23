using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer diContainer)
        {
            diContainer.RegisterFactory(c => new WorldGameplayRootViewModel()).AsSingle();
            diContainer.RegisterFactory(c => new UIGameplayRootViewModel(c.Resolve<SomeCommandService>())).AsSingle();
        }
    }
}
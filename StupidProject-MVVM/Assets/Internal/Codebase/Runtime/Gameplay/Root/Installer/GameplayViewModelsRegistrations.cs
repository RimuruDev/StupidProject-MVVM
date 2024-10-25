using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer diContainer)
        {
            diContainer.RegisterFactory(
                _ => new WorldGameplayRootViewModel(diContainer.Resolve<BuildingsService>())
            ).AsSingle();
            
            diContainer.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
        }
    }
}
using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer
{
    public static class GameplayInstaller
    {
        public static void Resolve(DIContainer diContainer, GameplayEnterParams gameplayEnterParams)
        {
            diContainer.RegisterFactory(container => new GameplayStatisticsService(container.Resolve<SomeCommandService>())).AsSingle();
        }
    }
}
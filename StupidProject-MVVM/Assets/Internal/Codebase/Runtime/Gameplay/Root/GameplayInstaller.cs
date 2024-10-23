using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root
{
    public static class GameplayInstaller
    {
        public static void Resolve(DIContainer diContainer, GameplayEnterParams gameplayEnterParams)
        {
            diContainer.RegisterFactory(container => new GameplayStatisticsService(container.Resolve<SomeCommandService>()));
        }
    }
}
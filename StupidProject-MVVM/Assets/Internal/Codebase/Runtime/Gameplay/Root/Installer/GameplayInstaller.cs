using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Runtime.Attributes;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Commands;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Services;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.Installer
{
    [Note("Разрешение зависимостей для Gameplay сцены.")]
    public static class GameplayInstaller
    {
        public static void Resolve(DIContainer diContainer, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = diContainer.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;

            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameStateProvider.GameState));
            diContainer.RegisterInstance<ICommandProcessor>(cmd);

            diContainer.RegisterFactory(_ => new BuildingsService(gameState.Buildings, cmd)).AsSingle();
        }
    }
}
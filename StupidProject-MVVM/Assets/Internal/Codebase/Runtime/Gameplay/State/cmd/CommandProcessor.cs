using System.Collections.Generic;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<System.Type, object> handlersMap = new();
        private readonly IGameStateProvider gameStateProvider;

        public CommandProcessor(IGameStateProvider gameStateProvider)
        {
            this.gameStateProvider = gameStateProvider;
        }

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> commandHandler)
            where TCommand : ICommand
        {
            handlersMap[typeof(TCommand)] = commandHandler;
        }

        public bool Process<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            if (handlersMap.TryGetValue(typeof(TCommand), out var handler))
            {
                var typedHandler = (ICommandHandler<ICommand>)handler;

                var result= typedHandler.Handle(command);

                if (result)
                {
                    gameStateProvider.SaveGameState();
                }
                
                return result;
            }

            return false;
        }
    }
}
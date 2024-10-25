namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd
{
    public interface ICommandProcessor
    {
        /// <summary>
        /// Регистрация обработчика команд.
        /// </summary>
        /// <param name="commandHandler">Обработчик команд.</param>
        /// <typeparam name="TCommand">Тип обрабатываемой команды.</typeparam>
        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> commandHandler)
            where TCommand : ICommand;

        /// <summary>
        /// Выполнения обработчика команд.
        /// </summary>
        /// <param name="command">Тип конкретной команды.</param>
        /// <typeparam name="TCommand">Тип конкретной команды.</typeparam>
        /// <returns>
        /// true - Обработчик команд успешно выполнил команду.
        /// false - Обработчик команд не смог выполнить команду.
        /// </returns>
        public bool Process<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.cmd
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="command">Тип команды.</param>
        /// <returns>
        /// true - команда успешно выполнена.
        /// false - команда не выполнена.
        /// </returns>
        public bool Handle(TCommand command);
    }
}
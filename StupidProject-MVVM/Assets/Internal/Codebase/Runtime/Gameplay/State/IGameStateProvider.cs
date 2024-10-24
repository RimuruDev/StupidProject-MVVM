using R3;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State
{
    public interface IGameStateProvider
    {
        /// <summary>
        /// Защищенная прокси состояния игры.
        /// </summary>
        public GameStateProxy GameState { get; }

        /// <summary>
        /// Сохраняет состояние игры.
        /// </summary>
        /// <returns>
        /// true - Успешно сохранено.
        /// false - Не получилось сохранить.
        /// </returns>
        public Observable<bool> SaveGameState();

        /// <summary>
        /// Загружает состояние игры.
        /// </summary>
        /// <returns>Защищенная прокси состояния игры.</returns>
        public Observable<GameStateProxy> LoadGameState();

        /// <summary>
        /// Сброс состояния игры.
        /// </summary>
        /// <returns>
        /// true - Состояние игры успешно сброшено.
        /// false - Не получилось сбросить состояние игры.
        /// </returns>
        public Observable<bool> ResetGameState();
    }
}
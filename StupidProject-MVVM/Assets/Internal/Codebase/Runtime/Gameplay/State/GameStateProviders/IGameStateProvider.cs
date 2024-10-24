using R3;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.Root;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.State.GameStateProviders
{
    public interface IGameStateProvider
    {
        /// <summary>
        /// Защищенная прокси состояния игры.
        /// </summary>
        public GameStateProxy GameState { get; }

        /// <summary>
        ///  Защищенная прокси настроек игры.
        /// </summary>
        public GameSettingsStateProxy SettingsState { get; }

        
        
        /// <summary>
        /// Сохраняет состояние игры.
        /// </summary>
        /// <returns>
        /// true - Состояние игры -> Успешно сохранено.
        /// false - Состояние игры -> Не получилось сохранить.
        /// </returns>
        public Observable<bool> SaveGameState();

        /// <summary>
        /// Сохраняет настройки игры.
        /// </summary>
        /// <returns>
        /// true - Настройки игры -> Успешно сохранено.
        /// false - Настройки игры -> Не получилось сохранить.
        /// </returns>
        public Observable<bool> SaveSettingsState();

        
        
        /// <summary>
        /// Загружает состояние игры.
        /// </summary>
        /// <returns>Защищенная прокси состояния игры.</returns>
        public Observable<GameStateProxy> LoadGameState();

        /// <summary>
        /// Загружает настройки игры.
        /// </summary>
        /// <returns>Защищенная прокси настройки игры.</returns>
        public Observable<GameSettingsStateProxy> LoadSettingsState();

        
        
        /// <summary>
        /// Сброс состояния игры.
        /// </summary>
        /// <returns>
        /// true - Состояние игры успешно сброшено.
        /// false - Не получилось сбросить состояние игры.
        /// </returns>
        public Observable<bool> ResetGameState();

        /// <summary>
        /// Сброс настроек игры.
        /// </summary>
        /// <returns>
        /// true - Настройки игры успешно сброшено.
        /// false - Не получилось сбросить настройки игры.
        /// </returns>
        public Observable<bool> ResetSettingsState();
    }
}
namespace AbyssMoth.Internal.Codebase.Infrastructure.Utilities
{
    /// <summary>
    /// Хранилище названий сцен, которые используются для короткого обращение к загрузке уровней через `ProjectSettings/EditorBuildSettings.asset` aka `SceneManager.LoadSceneAsync(sceneName);`
    /// А так же для различных сопоставлений.
    /// <example>
    ///
    /// </example>
    /// <code>
    /// private IEnumerator LoadScene(string sceneName)
    /// {
    ///     yield return SceneManager.LoadSceneAsync(SceneName.GAMEPLAY);
    /// }
    /// </code>
    /// </summary>
    public static class SceneName
    {
        /// <summary>
        /// Работает как точка входа и одновременно как TransitionBridge. То есть вызывает GC финализацию при переходах между сценами.
        /// Обычно использую отдельную сцену TransitionBridge.unity, но на этом проекте сцена Boot возьмет на себя эту роль.
        /// </summary>
        public static readonly string BOOT = "Boot";

        /// <summary>
        /// Сцена, которая служит прослойкой между первой частью игры (Boot/Registration и тп) и сценами с активным геймплеем.
        /// В Murder Drones Endless Way - это сена с магазинами. В танках - гараж. 
        /// </summary>
        public static readonly string MAIN_MENU = "MainMenu";

        /// <summary>
        /// Геймплей сцена (сцена на которой происходит сам игровой процесс).
        /// </summary>
        public static readonly string GAMEPLAY = "Gameplay";
    }
}
using AbyssMoth.Internal.Codebase.Infrastructure.Roots;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams
{
    public class GameplayEnterParams : SceneEnterParams
    {
        // Test ===
        public int LevelNumber { get; private set; }
        public string SaveFileName { get; private set; }

        public GameplayEnterParams(string sceneName, string saveFileName, int levelNumber) : base(sceneName)
        {
            SaveFileName = saveFileName;
            LevelNumber = levelNumber;
        }
    }
}
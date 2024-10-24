using AbyssMoth.Internal.Codebase.Infrastructure.Roots;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams
{
    public class MainMenuExitParams
    {
        public SceneEnterParams TargetSceneEnterParams { get; }

        public MainMenuExitParams(SceneEnterParams targetSceneEnterParams)
        {
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}
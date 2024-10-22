using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root;
using AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.View;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root
{
    public class MainMenuExitParams
    {
        public GameplayEnterParams GameplayEnterParams { get; }

        public MainMenuExitParams(GameplayEnterParams gameplayEnterParams)
        {
            GameplayEnterParams = gameplayEnterParams;
        }
    }
}
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root.GameplayParams
{
    public class GameplayExitParams
    {
        public MainMenuEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams)
        {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}
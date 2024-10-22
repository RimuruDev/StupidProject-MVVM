using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root;

namespace AbyssMoth.Internal.Codebase.Runtime.Gameplay.Root
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
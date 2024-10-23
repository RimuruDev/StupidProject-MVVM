using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.Installer
{
    public static class MainMenuViewModelsRegistrations
    {
        public static void Register(DIContainer diContainer)
        {
            diContainer.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}
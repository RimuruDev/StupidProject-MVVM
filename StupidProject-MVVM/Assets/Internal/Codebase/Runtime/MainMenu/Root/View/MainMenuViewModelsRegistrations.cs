using AbyssMoth.DI;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public static class MainMenuViewModelsRegistrations
    {
        public static void Register(DIContainer diContainer)
        {
            diContainer.RegisterFactory(c => new UIMainMenuRootViewModel());
        }
    }
}
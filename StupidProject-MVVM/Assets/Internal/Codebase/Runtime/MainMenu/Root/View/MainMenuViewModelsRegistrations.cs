using AbyssMoth.Internal.Codebase.DI.Container;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.View
{
    public static class MainMenuViewModelsRegistrations
    {
        public static void Resolve(DIContainer diContainer)
        {
            diContainer.RegisterFactory(c => new UIMainMenuRootViewModel());
        }
    }
}
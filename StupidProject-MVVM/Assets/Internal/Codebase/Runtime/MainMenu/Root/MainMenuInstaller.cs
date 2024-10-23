using AbyssMoth.Internal.Codebase.DI.Container;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root
{
    public static class MainMenuInstaller
    {
        public static void Resolve(DIContainer diContainer, MainMenuEnterParams mainMenuEnterParams)
        {
            diContainer.RegisterFactory(container => new SkinShopService(container.Resolve<SomeCommandService>()));
        }
    }
}
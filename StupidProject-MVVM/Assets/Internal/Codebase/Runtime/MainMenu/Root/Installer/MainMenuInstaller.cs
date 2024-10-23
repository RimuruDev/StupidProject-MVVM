using AbyssMoth.DI;
using AbyssMoth.Internal.Codebase.Infrastructure.Services;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.MainMenuParams;
using AbyssMoth.Internal.Codebase.Runtime.MainMenu.Services;

namespace AbyssMoth.Internal.Codebase.Runtime.MainMenu.Root.Installer
{
    public static class MainMenuInstaller
    {
        public static void Resolve(DIContainer diContainer, MainMenuEnterParams mainMenuEnterParams)
        {
            diContainer.RegisterFactory(container => new SkinShopService(container.Resolve<SomeCommandService>()));
        }
    }
}
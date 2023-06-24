using UI.Lobby;
using UI.Lobby.Interfaces;
using Zenject;

namespace Lobby.DI
{
    internal class LobbyInstaller : Installer<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LobbyService>().AsSingle();
            Container.Bind<IPlayersPrinter>().To<LobbyPlayersPrinter>().AsSingle();
            Container.Bind<ILobbiesPrinter>().To<LobbiesPrinter>().AsSingle();
        }
    }
}

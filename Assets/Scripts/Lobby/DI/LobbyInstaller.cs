using Lobby.Interfaces;
using Zenject;

namespace Lobby.DI
{
    internal class LobbyInstaller : Installer<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILobbySystem>().To<LobbySystem>().AsSingle();
            Container.Bind<ILobbyOwner>().To<LobbyOwner>().AsSingle();
            Container.Bind<ILobbyMember>().To<LobbyMember>().AsSingle();
        }
    }
}

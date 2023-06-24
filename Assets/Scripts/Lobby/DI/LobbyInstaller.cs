using Assets.Scripts.Lobby.Interfaces;
using Lobby;
using Lobby.Interfaces;
using Zenject;

namespace Assets.Scripts.Lobby.DI
{
    internal class LobbyInstaller : MonoInstaller<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILobbySystem>().To<LobbySystem>().AsSingle();
            Container.Bind<ILobbyOwner>().To<LobbyOwner>().AsSingle();
            Container.Bind<ILobbyMember>().To<LobbyMember>().AsSingle();
        }
    }
}

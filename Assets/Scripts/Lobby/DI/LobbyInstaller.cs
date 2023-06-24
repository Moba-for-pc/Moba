using Zenject;

namespace Assets.Scripts.Lobby.DI
{
    internal class LobbyInstaller : Installer<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILobbyService>().To<TestLobby>().AsTransient();
        }
    }
}

using Zenject;

namespace Assets.Scripts.Lobby.DI
{
    internal class LobbyInstaller : MonoInstaller<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILobbyService>().To<TestLobby>().AsTransient();
        }
    }
}

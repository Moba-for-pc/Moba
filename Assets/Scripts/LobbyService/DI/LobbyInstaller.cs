using Assets.Scripts.LobbyService.Displays;
using Zenject;

namespace Assets.Scripts.LobbyService.DI
{
    internal class LobbyInstaller : Installer<LobbyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LobbyService>().AsSingle();
            Container.Bind<ILobbiesDisplay>().To<LobbiesDisplay>().AsSingle();
        }
    }
}

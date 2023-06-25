using Assets.Scripts.Authentication.DI;
using Assets.Scripts.UnityService.DI;
using Assets.Scripts.Lobby.DI;
using Zenject;

namespace Assets.Scripts
{

    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AuthenticationInstaller.Install(Container);
            UnityServiceInstaller.Install(Container);
            LobbyInstaller.Install(Container);
        }
    }
}
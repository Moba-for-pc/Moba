using Assets.Scripts.Authentication.DI;
using Assets.Scripts.Database.DI;
using Assets.Scripts.UnityService.DI;
using Zenject;

namespace Assets.Scripts
{

    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            UnityServiceInstaller.Install(Container);
            AuthenticationInstaller.Install(Container);
            DatabaseInstaller.Install(Container);
        }
    }
}
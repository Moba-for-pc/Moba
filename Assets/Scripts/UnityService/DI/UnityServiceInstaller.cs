using Zenject;

namespace Assets.Scripts.UnityService.DI
{
    internal class UnityServiceInstaller : Installer<UnityServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUnityService>().To<UnityServiceImpl>().AsSingle();
        }
    }
}

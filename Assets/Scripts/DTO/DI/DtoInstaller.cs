using Zenject;

namespace Assets.Scripts.DTO.DI
{
    public class DtoInstaller : Installer<DtoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Player>().AsSingle();
            Container.Bind<Lobby>().AsSingle();
        }
    }
}
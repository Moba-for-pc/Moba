using Assets.Scripts.Database.Repositories;
using Zenject;

namespace Assets.Scripts.Database.DI
{
    public class DatabaseInstaller : Installer<DatabaseInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerRepository>().To<PlayerRepository>().AsTransient();
        }
    }
}

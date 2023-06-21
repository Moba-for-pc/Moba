using Assets.Scripts.Authentication.DI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{

    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AuthenticationInstaller.Install(Container);
        }
    }
}
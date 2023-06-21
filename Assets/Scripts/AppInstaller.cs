using Assets.Scripts.Authentication.DI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{

    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Injection started");
            AuthenticationInstaller.Install(Container);
            Debug.Log("Injection ended");
        }
    }
}
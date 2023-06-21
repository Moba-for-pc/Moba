using Assets.Scripts.Authentication.AppleAuthentication;
using Assets.Scripts.Authentication.FacebookAuthentication;
using Assets.Scripts.Authentication.GoogleAuthentication;
using Assets.Scripts.Authentication.GuestAuthentication;
using Assets.Scripts.Authentication.SteamAuthentication;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Authentication.DI
{
    public class AuthenticationInstaller : Installer<AuthenticationInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAppleAuth>().To<AppleAuth>().AsTransient();
            Container.Bind<IFacebookAuth>().To<FacebookAuth>().AsTransient();
            Container.Bind<IGoogleAuth>().To<GoogleAuth>().AsTransient();
            Container.Bind<IGuestAuth>().To<GuestAuth>().AsTransient();
            Container.Bind<ISteamAuth>().To<SteamAuth>().AsTransient();
         
            Container.Bind<IAuthenticator>().To<Authenticator>().AsTransient();
            Debug.Log("Auth Dependencies injected");
        }
    }
}
using Assets.Scripts.UnityService;
using System;
using Unity.Services.Authentication;
using Unity.Services.Core;

namespace Assets.Scripts.Authentication.GuestAuthentication
{
    public class GuestAuth : IGuestAuth
    {
        public event Action Authenticated;
        private IUnityService _unityService;

        public GuestAuth(IUnityService unityService)
        {
            _unityService = unityService;
            _unityService.InitIfNeeded();
        }

        public async void Authenticate()
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        public async void AuthenticateWithUsername(string username)
        {

            InitializationOptions options = new InitializationOptions();
            options.SetProfile(username);
            _unityService.ReInitWithOptions(options);
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }
}
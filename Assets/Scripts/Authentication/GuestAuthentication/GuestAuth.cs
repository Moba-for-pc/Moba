using Assets.Scripts.UnityService;
using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

namespace Assets.Scripts.Authentication.GuestAuthentication
{
    public class GuestAuth : IGuestAuth
    {
        public event Action Authenticated;
        private IUnityService _unityService;

        public GuestAuth(IUnityService unityService)
        {
            _unityService = unityService;
            _unityService.InitIfNeededAsync();
        }

        public async Task AuthenticateAsync()
        {
            if (AuthenticationService.Instance.IsSignedIn)
            {
                Debug.Log(ExceptionMessages.ALREADY_AUTHENTICATED);
                return;
            }
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        public async Task AuthenticateWithUsernameAsync(string username)
        {
            InitializationOptions options = new InitializationOptions();
            options.SetProfile(username);
            await _unityService.ReInitWithOptionsAsync(options);
            AuthenticationService.Instance.SwitchProfile(username);
            await AuthenticateAsync();
        }
    }
}
using System;
using Unity.Services.Authentication;
using Unity.Services.Core;

namespace Assets.Scripts.Authentication.UnityAuthentication
{
    public class UnityAuth : IUnityAuth
    {
        public UnityAuth()
        {
            UnityServices.InitializeAsync();
        }

        public void Authenticate(string token)
        {
            AuthenticationService.Instance.SignInWithUnityAsync(token);
        }

        public void Authenticate()
        {
            throw new NotImplementedException();
        }

        public string GetUserId()
        {
            return AuthenticationService.Instance.PlayerId;
        }

        public bool IsAuthenticated()
        {
            return AuthenticationService.Instance.IsSignedIn;
        }
    }
}

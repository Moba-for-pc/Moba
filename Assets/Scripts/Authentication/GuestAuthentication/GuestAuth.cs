using Unity.Services.Core;
using Unity.Services.Authentication;
using System;

namespace Assets.Scripts.Authentication.GuestAuthentication
{
    public class GuestAuth : IGuestAuth
    {
        public GuestAuth()
        {
            UnityServices.InitializeAsync();
        }

        public void Authenticate()
        {
            AuthenticationService.Instance.SignInAnonymouslyAsync();
            
        }

        public string GetUserId()
        {
            if (!IsAuthenticated())
                throw new InvalidOperationException(ExceptionMessages.USER_NOT_AUTHENTICATED);
            return AuthenticationService.Instance.PlayerId;
        }

        public bool IsAuthenticated()
        {
            return AuthenticationService.Instance.IsSignedIn;
        }
    }
}

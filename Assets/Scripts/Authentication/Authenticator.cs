using System;
using System.Collections.Generic;

namespace Assets.Scripts.Authentication
{
    public class Authenticator : IAuthenticator
    {
        public event Action AuthenticationRequested;

        private List<IAuthenticationProvider> _authProviders;

        public void Authenticate()
        {
            AuthenticationRequested?.Invoke();
        }

        public string GetUserId()
        {
            foreach (var provider in _authProviders)
            {
                if (provider.IsAuthenticated())
                {
                    return provider.GetUserId();
                }
            }
            throw new NotAuthenticatedException(ExceptionMessages.USER_NOT_AUTHENTICATED);
        }

        public bool IsAuthenticated()
        {
            foreach (var provider in _authProviders)
            {
                if (provider.IsAuthenticated())
                    return true;
            }
            return false;
        }
    }
}
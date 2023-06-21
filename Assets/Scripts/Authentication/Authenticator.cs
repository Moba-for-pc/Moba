using Assets.Scripts.Authentication.AppleAuthentication;
using Assets.Scripts.Authentication.FacebookAuthentication;
using Assets.Scripts.Authentication.GoogleAuthentication;
using Assets.Scripts.Authentication.GuestAuthentication;
using Assets.Scripts.Authentication.SteamAuthentication;
using System;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Authentication
{
    public class Authenticator : IAuthenticator
    {
        public event Action AuthenticationRequested;

        private List<IAuthenticationProvider> _authProviders;

        public Authenticator(IAppleAuth appleAuth, IFacebookAuth facebookAuth, IGoogleAuth googleAuth, IGuestAuth guestAuth, ISteamAuth steamAuth)
        {
            _authProviders = new List<IAuthenticationProvider>();
            _authProviders.Add(appleAuth);
            _authProviders.Add(facebookAuth);
            _authProviders.Add(googleAuth);
            _authProviders.Add(guestAuth);
            _authProviders.Add(steamAuth);
        }

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
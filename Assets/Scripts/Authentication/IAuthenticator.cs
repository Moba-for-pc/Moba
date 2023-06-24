using System;

namespace Assets.Scripts.Authentication
{
    public interface IAuthenticator
    {
        public event Action Authenticated;
        public event Action Deauthenticated;
        public string GetUserId();
        public bool IsAuthenticated();
        public void Deauthenticate();
    }
}
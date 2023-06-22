using System;

namespace Assets.Scripts.Authentication.GuestAuthentication
{
    public interface IGuestAuth
    {
        public event Action Authenticated;
        public void Authenticate();
        public void AuthenticateWithUsername(string username);
    }
}
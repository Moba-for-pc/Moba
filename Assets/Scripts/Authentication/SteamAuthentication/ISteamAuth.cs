using System;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public interface ISteamAuth
    {
        public event Action Authenticated;
        public void Authenticate();
    }
}
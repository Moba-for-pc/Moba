using System;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public class SteamAuth : ISteamAuth
    {
        public event Action Authenticated;

        public void Authenticate()
        {
            throw new System.NotImplementedException(); // TODO подулючить Steam сервисы
        }

    }
}

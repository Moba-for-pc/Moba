using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public class SteamAuth : ISteamAuth
    {
        public event Action Authenticated;

        public Task Authenticate()
        {
            throw new System.NotImplementedException(); // TODO подулючить Steam сервисы
        }

    }
}

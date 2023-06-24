using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public class SteamAuth : ISteamAuth
    {
        public event Action Authenticated;

        public Task AuthenticateAsync()
        {
            throw new System.NotImplementedException(); // TODO подулючить Steam сервисы
        }

    }
}

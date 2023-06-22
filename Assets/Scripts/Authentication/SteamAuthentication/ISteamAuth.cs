using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public interface ISteamAuth
    {
        public event Action Authenticated;
        public Task Authenticate();
    }
}
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.SteamAuthentication
{
    public interface ISteamAuth
    {
        public Task AuthenticateAsync();
    }
}
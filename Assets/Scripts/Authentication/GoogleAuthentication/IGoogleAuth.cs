using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.GoogleAuthentication
{
    public interface IGoogleAuth
    {
        public event Action Authenticated;
        public Task Authenticate();
    }
}
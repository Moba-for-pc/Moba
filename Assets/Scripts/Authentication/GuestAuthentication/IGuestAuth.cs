using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.GuestAuthentication
{
    public interface IGuestAuth
    {
        public Task AuthenticateAsync();
        public Task AuthenticateWithUsernameAsync(string username);
    }
}
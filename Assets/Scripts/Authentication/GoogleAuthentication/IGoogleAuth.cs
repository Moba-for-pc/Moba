using System;

namespace Assets.Scripts.Authentication.GoogleAuthentication
{
    public interface IGoogleAuth
    {
        public event Action Authenticated;
        public void Authenticate();
    }
}
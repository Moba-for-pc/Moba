using System;

namespace Assets.Scripts.Authentication.GoogleAuthentication
{
    public class GoogleAuth : IGoogleAuth
    {
        public event Action Authenticated;

        public void Authenticate()
        {
            throw new NotImplementedException();  //TODO подключить гугл сервисы

        }


        public bool IsAuthenticated()
        {
            return false;
        }
    }
}

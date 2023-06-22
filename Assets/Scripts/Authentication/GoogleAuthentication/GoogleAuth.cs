using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Authentication.GoogleAuthentication
{
    public class GoogleAuth : IGoogleAuth
    {
        public event Action Authenticated;

        public Task Authenticate()
        {
            throw new NotImplementedException();  //TODO подключить гугл сервисы

        }
    }
}

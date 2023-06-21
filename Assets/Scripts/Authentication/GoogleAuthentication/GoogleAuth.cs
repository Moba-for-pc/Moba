using Unity.Services.Authentication;
using Unity.Services.Core;

namespace Assets.Scripts.Authentication.GoogleAuthentication
{
    public class GoogleAuth : IGoogleAuth
    {
        public GoogleAuth()
        {
            UnityServices.InitializeAsync();
        }

        public void Authenticate()
        {
            
            
        }

        public string GetUserId()
        {
            throw new System.NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            return false;
        }
    }
}

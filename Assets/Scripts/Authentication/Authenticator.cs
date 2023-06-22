using Assets.Scripts.UnityService;
using Unity.Services.Authentication;

namespace Assets.Scripts.Authentication
{
    public class Authenticator : IAuthenticator
    {

        public Authenticator(IUnityService unityService)
        {
            unityService.InitIfNeededAsync();
        }

        public void Deauthenticate()
        {
            AuthenticationService.Instance.SignOut();
        }

        public string GetUserId()
        {
            if (!IsAuthenticated())
                throw new NotAuthenticatedException(ExceptionMessages.USER_NOT_AUTHENTICATED);

            return AuthenticationService.Instance.PlayerId;
        }

        public bool IsAuthenticated()
        {
            return AuthenticationService.Instance.IsSignedIn;
        }
    }
}
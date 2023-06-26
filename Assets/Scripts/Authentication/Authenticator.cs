using Assets.Scripts.UnityService;
using System;
using Unity.Services.Authentication;
using Zenject;

namespace Assets.Scripts.Authentication
{
    public class Authenticator : IAuthenticator, IInitializable
    {
        public event Action Authenticated;
        public event Action Deauthenticated;

        public Authenticator(IUnityService unityService)
        {
            unityService.InitIfNeededAsync();
        }

        public void Initialize()
        {
            AuthenticationService.Instance.SignedIn += OnSignedIn;
            AuthenticationService.Instance.SignedOut += OnSignedOut;
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

        private void OnSignedIn()
        {
            Authenticated?.Invoke();
        }

        private void OnSignedOut()
        {
            Deauthenticated?.Invoke();
        }

        ~Authenticator()
        {
            AuthenticationService.Instance.SignedIn -= OnSignedIn;
            AuthenticationService.Instance.SignedOut -= OnSignedOut;
        }
    }
}
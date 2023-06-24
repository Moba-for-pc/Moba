using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Authentication.AuthenticationRequest
{
    public class AuthRequest : IAuthRequest
    {
        public const string AUTH_SCENE_NAME = "AuthenticationTestScene";

        private int _sceneToRedirectWhenAuthDoneBuildIndex;
        private IAuthenticator _authenticator;

        public AuthRequest(IAuthenticator authenticator) 
        { 
            _authenticator = authenticator;
        }

        public void RedirectUserToAuthSceneAndBack()
        {
            if (_authenticator.IsAuthenticated())
            {
                Debug.Log(ExceptionMessages.ALREADY_AUTHENTICATED);
                return;
            }
            
            _authenticator.Authenticated += OnAuthenticated;
            _sceneToRedirectWhenAuthDoneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(AUTH_SCENE_NAME, LoadSceneMode.Single);
        }

        private void OnAuthenticated()
        {
            SceneManager.LoadScene(_sceneToRedirectWhenAuthDoneBuildIndex, LoadSceneMode.Single);
            _authenticator.Authenticated -= OnAuthenticated;
        }

        ~AuthRequest()
        {
            Debug.Log("Request destroyed");
        }
    }
}

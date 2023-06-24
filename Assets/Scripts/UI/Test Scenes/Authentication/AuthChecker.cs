using Assets.Scripts.Authentication;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.TestScenes.Authentication.AuthenticationScene
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AuthChecker : MonoBehaviour
    {
        private IAuthenticator _authenticator;

        private TextMeshProUGUI _authStateText;

        [Inject]
        public void Init(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        private void Start()
        {
            TryGetComponent(out _authStateText);
            UpdateAuthState();
        }

        private void OnEnable()
        {
            _authenticator.Authenticated += UpdateAuthState;
            _authenticator.Deauthenticated += UpdateAuthState;
        }

        private void OnDisable()
        {
            _authenticator.Authenticated -= UpdateAuthState;
            _authenticator.Deauthenticated -= UpdateAuthState;
        }

        private void UpdateAuthState()
        {
            _authStateText.text = (_authenticator.IsAuthenticated()) ? $"Authenticated!! userID: {_authenticator.GetUserId()}" : "you're not authenticated";
        }
    }
}
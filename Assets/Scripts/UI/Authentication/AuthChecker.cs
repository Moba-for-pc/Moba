using Assets.Scripts.Authentication;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Ui.Authentication
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

        private void Awake()
        {
            TryGetComponent(out _authStateText);
        }

        private void Update()
        {
            UpdateAuthState();
        }

        private void UpdateAuthState()
        {
            _authStateText.text = (_authenticator.IsAuthenticated()) ? $"Authenticated!! userID: {_authenticator.GetUserId()}" : "you're not authenticated";
        }
    }
}
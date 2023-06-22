using Assets.Scripts.Authentication;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Authentication
{
    [RequireComponent(typeof(Button))]
    public class SignOutButton : MonoBehaviour
    {
        private Button _signOutButton;

        private IAuthenticator _authenticator;

        [Inject]
        public void Init(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        private void Awake()
        {
            TryGetComponent(out _signOutButton);

            _signOutButton.onClick.AddListener(() => {
                SignOut();
            });
        }
        private void SignOut()
        {
            _authenticator.Deauthenticate();
        }
    }

}
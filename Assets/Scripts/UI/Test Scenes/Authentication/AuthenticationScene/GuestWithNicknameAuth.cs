using Assets.Scripts.Authentication.GuestAuthentication;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.TestScenes.Authentication.AuthenticationScene
{
    public class GuestWithNicknameAuth : MonoBehaviour
    {

        [SerializeField] private Button _startAuthButton;
        [SerializeField] private TMP_InputField _tokenInput;

        private IGuestAuth _guestAuth;

        [Inject]
        public void Init(IGuestAuth guestAuth)
        {
            _guestAuth = guestAuth;
        }

        private void Awake()
        {
            _startAuthButton.onClick.AddListener(async () => {
                await _guestAuth.AuthenticateWithUsernameAsync(_tokenInput.text);
            });
        }
    }
}
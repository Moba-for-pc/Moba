using Assets.Scripts.Authentication;
using Assets.Scripts.Authentication.AuthenticationRequest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.TestScenes.Authentication.AuthRequestScene
{
    [RequireComponent(typeof(Button))]
    public class CreateAuthRequestButton : MonoBehaviour
    {
        private Button _sendRequestButton;
        private IAuthRequest _authRequest;

        [Inject]
        public void Init(IAuthRequest authRequest)
        {
            _authRequest = authRequest;
        }

        private void Awake()
        {
            TryGetComponent(out _sendRequestButton);
            _sendRequestButton.onClick.AddListener(() =>
                {
                    _authRequest.RedirectUserToAuthSceneAndBack();
                }
            );
        }
    }
}
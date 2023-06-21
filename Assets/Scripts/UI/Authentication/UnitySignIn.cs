using Assets.Scripts.Authentication;
using Assets.Scripts.Authentication.UnityAuthentication;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UnitySignIn : MonoBehaviour
{
    [SerializeField] private Button _startAuthButton;
    [SerializeField] private TMP_InputField _tokenInput;

    private IUnityAuth _authenticator;

    [Inject]
    public void Init(IUnityAuth authenticator) { 
        _authenticator = authenticator;
    }

    private void Awake()
    {
        _startAuthButton.onClick.AddListener(() => {
            _authenticator.Authenticate(_tokenInput.text);
        });
    }
}

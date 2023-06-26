using Assets.Scripts.Authentication;
using Assets.Scripts.Authentication.AuthenticationRequest;
using UnityEngine;
using Zenject;

public class FastAuthRequest : MonoBehaviour
{
    private IAuthRequest _authRequest;
    private IAuthenticator _authenticator;

    [Inject]
    public void Init(IAuthRequest authRequest, IAuthenticator authenticator)
    {
        _authRequest = authRequest;
        _authenticator = authenticator;
    }

    private void Start()
    {
        if (!_authenticator.IsAuthenticated())
        {
            _authRequest.RedirectUserToAuthSceneAndBack();
        }
        else
        {
            Destroy(gameObject); // добавить чистку ссылок, реквест не удаляется при уничтожении объекта
        }
    }
}

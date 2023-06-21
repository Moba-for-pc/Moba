using Assets.Scripts.Authentication;
using UnityEngine;
using Zenject;

public class AuthTest : MonoBehaviour
{ // TODO удалить
    private IAuthenticator _authenticator;

    private void Awake()
    {
       Authenticate();
    }

    [Inject]
    public void Init(IAuthenticator authenticator)
    {
        _authenticator = authenticator;
        Debug.Log("auth user initialized");
    }

    public void Authenticate()
    {
        Debug.Log("Auth method called");
        _authenticator.Authenticate();
    }
}

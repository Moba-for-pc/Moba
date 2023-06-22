using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class TestLobby : MonoBehaviour
{
    public TMP_InputField inputLobbyCode;
    private Lobby _lobby;

    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void OnCreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 4;

            _lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers);
            Debug.Log(_lobby.Name + $" lobby created with {_lobby.MaxPlayers} max players. Lobby code: " + _lobby.LobbyCode);
        }
        catch (LobbyServiceException exception)
        {
            Debug.Log(exception);
        }
    }

    public async void OnJoinLobbyByCode()
    {
        string lobbyCode = inputLobbyCode.text;
        try
        {
            await Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode);
            Debug.Log("Joined lobby with name " + _lobby.Name);
        }
        catch (LobbyServiceException exception)
        {
            Debug.Log( exception);
        }
    }
}

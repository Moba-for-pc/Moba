using Lobby.Interfaces;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using UnityEngine;
using Zenject;

namespace Lobby
{
    public class LobbyMember : ILobbyMember
    {
        private ILobbySystem _lobbySystem;
        
        [Inject]
        private LobbyMember(ILobbySystem lobbySystem)
        {
            _lobbySystem = lobbySystem;
        }
        
        public async void JoinLobbyByCode(string code)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code);
                Debug.Log("Joined lobby with name " + lobby.Name);
                _lobbySystem.PrintPlayers(lobby);
            }
            catch (LobbyServiceException e)
            {
                Debug.LogError(e);
            }
        }

        public async void ExitLobby(Unity.Services.Lobbies.Models.Lobby lobby)
        {
            try
            {
                await Lobbies.Instance.RemovePlayerAsync(lobby.Id, AuthenticationService.Instance.PlayerId);
                Debug.Log($"Exit from {lobby.Name}");
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }
    }
}
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Lobby
{
    public class LobbyService : ILobbyService, IFixedTickable
    {
        private Unity.Services.Lobbies.Models.Lobby _currentLobby;
        private float _heartbeatTimer;

        #region Heartbeat
        
        public void FixedTick() => HandleLobbyHeartbeat();

        private async void HandleLobbyHeartbeat()
        {
            if (_currentLobby == null) return;
            if (_currentLobby.HostId == AuthenticationService.Instance.PlayerId) return;
        
            _heartbeatTimer -= Time.fixedDeltaTime;
            if (_heartbeatTimer <= 0f)
            {
                float heartbeatTimerMax = 15;
                _heartbeatTimer = heartbeatTimerMax;

                await Unity.Services.Lobbies.LobbyService.Instance.SendHeartbeatPingAsync(_currentLobby.Id);
            }
        }
        
        #endregion

        public async void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions)
        {
            try
            {
                Unity.Services.Lobbies.Models.
                    Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);
                _currentLobby = lobby;
                
                Debug.Log(lobby.Name + $" lobby created with {lobby.MaxPlayers} max players. Lobby code: " + lobby.LobbyCode);
            }
            catch (LobbyServiceException e){ Debug.LogError(e); }
        }

        public async void DeleteLobby()
        {
            try
            {
                await Lobbies.Instance.DeleteLobbyAsync(_currentLobby.Id);
                Debug.Log($"Lobby {_currentLobby.Name} deleted");
            }
            catch (LobbyServiceException e){Debug.LogError(e);}
        }
        
        public async void JoinLobbyByCode(string code)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code);
                _currentLobby = lobby;
                
                Debug.Log("Joined lobby with name " + lobby.Name);
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }

        public async void ExitLobby(string id)
        {
            try
            {
                await Lobbies.Instance.RemovePlayerAsync(_currentLobby.Id, id);
                Debug.Log($"Exit from {_currentLobby.Name}");
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }
        
        public Unity.Services.Lobbies.Models.Lobby GetHostLobby() {return _currentLobby;}
    }
}
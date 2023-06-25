using System;
using Unity.Services.Lobbies;
using UnityEngine;
using Zenject;
using ILobbyService = Lobby.Interfaces.ILobbyService;

namespace Lobby
{
    public class LobbyService : ILobbyService, IFixedTickable
    {
        private Unity.Services.Lobbies.Models.Lobby _hostLobby;
        private float _heartbeatTimer;
        
        #region Heartbeat
        
        public void FixedTick() => HandleLobbyHeartbeat();

        private async void HandleLobbyHeartbeat()
        {
            if (_hostLobby == null) return;
        
            _heartbeatTimer -= Time.fixedDeltaTime;
            if (_heartbeatTimer <= 0f)
            {
                float heartbeatTimerMax = 15;
                _heartbeatTimer = heartbeatTimerMax;

                await Unity.Services.Lobbies.LobbyService.Instance.SendHeartbeatPingAsync(_hostLobby.Id);
            }
        }
        
        #endregion

        public async void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions)
        {
            try
            {
                Unity.Services.Lobbies.Models.
                    Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);
                _hostLobby = lobby;
                
                Debug.Log(lobby.Name + $" lobby created with {lobby.MaxPlayers} max players. Lobby code: " + lobby.LobbyCode);
            }
            catch (LobbyServiceException e){ Debug.LogError(e); }
        }

        public async void KickPlayer() // No usage, waiting for UI
        {
            try
            {
                await Unity.Services.Lobbies.LobbyService.Instance.RemovePlayerAsync(_hostLobby.Id,
                    _hostLobby.Players[1].Id);
            }
            catch (LobbyServiceException e){ Debug.LogError(e); }
        }

        public async void DeleteLobby()
        {
            try
            {
                await Lobbies.Instance.DeleteLobbyAsync(_hostLobby.Id);
                Debug.Log($"Lobby {_hostLobby.Name} deleted");
            }
            catch (LobbyServiceException e){Debug.LogError(e);}
        }
        
        public async void JoinLobbyByCode(string code)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code);
                _hostLobby = lobby;
                
                Debug.Log("Joined lobby with name " + lobby.Name);
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }

        public async void ExitLobby(string id)
        {
            try
            {
                await Lobbies.Instance.RemovePlayerAsync(_hostLobby.Id, id);
                Debug.Log($"Exit from {_hostLobby.Name}");
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }
        
        public Unity.Services.Lobbies.Models.Lobby GetHostLobby() {return _hostLobby;}
    }
}
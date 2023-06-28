using System;
using System.Collections.Generic;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.LobbyService
{
    public class LobbyService : ILobbyService, IFixedTickable
    {
        private Lobby _lobby;
        private Player _player;
        private float _heartbeatTimer;

        private const int HeartbeatTimerMax = 15;

        public event Action OnPlayerCountChange;

        #region Heartbeat

        public void FixedTick() => HandleLobbyHeartbeat();

        private async void HandleLobbyHeartbeat()
        {
            if (_lobby.HostId == null) return;
            if (_lobby.HostId != _player.Id) return;
        
            _heartbeatTimer -= Time.fixedDeltaTime;
            if (_heartbeatTimer <= 0f)
            {
                _heartbeatTimer = HeartbeatTimerMax;

                await Unity.Services.Lobbies.LobbyService.Instance.SendHeartbeatPingAsync(_lobby.Id);
            }
        }
        
        #endregion
        
        private void SetLobbyData(Unity.Services.Lobbies.Models.Lobby lobby)
        {
            _lobby.Name = lobby.Name;
            _lobby.Id = lobby.Id;
            _lobby.HostId = lobby.HostId;
            _lobby.Players.Add(_player);
        }
        
        #region CreateLobby
        
        private CreateLobbyOptions CreateLobbyOptions(bool isPrivate, Dictionary<string, DataObject> data)
        {
            LobbyOptionsBuilder lobbyOptionsBuilder = new LobbyOptionsBuilder().Reset();
            
            lobbyOptionsBuilder.SetIsPrivate(isPrivate)
                .SetData(data);
            
            return lobbyOptionsBuilder.Build();
        }

        public async void CreateLobby(string lobbyName, int maxPlayers, bool isPrivate, Dictionary<string, DataObject> data)
        {
            try
            {
                CreateLobbyOptions lobbyOptions = CreateLobbyOptions(isPrivate, data);
                Unity.Services.Lobbies.Models.Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, lobbyOptions);
                SetLobbyData(lobby);
                
                Debug.Log(lobby.Name + $" lobby created with {lobby.MaxPlayers} max players. Lobby code: " + lobby.LobbyCode);
            }
            catch (LobbyServiceException e){ Debug.LogError(e); }

            OnPlayerCountChange?.Invoke();
        }

        #endregion
        
        public async void DeleteLobby()
        {
            if (_lobby.HostId != _player.Id) return;
            
            try { await Lobbies.Instance.DeleteLobbyAsync(_lobby.Id); }
            
            catch (LobbyServiceException e){Debug.LogError(e);}
            
            Debug.Log($"Lobby {_lobby.Name} deleted");
            _lobby = new Lobby();
        }
        
        public async void JoinLobbyByCode(string code)
        {
            if (_lobby.HostId == null) return;
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code);
                SetLobbyData(lobby);
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
            
            Debug.Log("Joined lobby with name " + _lobby.Name);
            OnPlayerCountChange?.Invoke();
        }

        public async void ExitLobby(string id)
        {
            if (_lobby.HostId == null) return;
            
            try { await Lobbies.Instance.RemovePlayerAsync(_lobby.Id, id); }
            
            catch (LobbyServiceException e) { Debug.LogError(e); }
            
            Debug.Log($"Exit from {_lobby.Name}");
            _lobby = new Lobby();
            OnPlayerCountChange?.Invoke();
        }
    }
}
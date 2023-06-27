using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using Zenject;
using Lobby = Assets.Scripts.DTO.Lobby;
using Player = Assets.Scripts.DTO.Player;

namespace Assets.Scripts.LobbyService
{
    public class LobbyService : ILobbyService, IFixedTickable
    {
        private LobbyOptionsBuilder _lobbyOptionsBuilder;
        private Lobby _lobby;
        private Player _player;
        private float _heartbeatTimer;

        [Inject]
        private LobbyService(LobbyOptionsBuilder lobbyOptionsBuilder, Lobby lobby, Player player)
        {
            _lobbyOptionsBuilder = lobbyOptionsBuilder;
            _lobby = lobby;
            _player = player;
        }

        #region Heartbeat

        public void FixedTick() => HandleLobbyHeartbeat();

        private async void HandleLobbyHeartbeat()
        {
            if (_lobby.CurrentLobby == null) return;
            if (_lobby.HostId == _player.Id) return;
        
            _heartbeatTimer -= Time.fixedDeltaTime;
            if (_heartbeatTimer <= 0f)
            {
                float heartbeatTimerMax = 15;
                _heartbeatTimer = heartbeatTimerMax;

                await Unity.Services.Lobbies.LobbyService.Instance.SendHeartbeatPingAsync(_lobby.CurrentLobby.Id);
            }
        }
        
        #endregion

        #region LobbyData
        
        private void SetLobbyData(Unity.Services.Lobbies.Models.Lobby lobby)
        {
            _lobby.CurrentLobby = lobby;
            _lobby.Name = lobby.Name;
            _lobby.Id = lobby.Id;
            _lobby.HostId = lobby.HostId;
            _lobby.Players.Add(_player);
        }

        private void DeleteLobbyData()
        {
            _lobby = new Lobby();
            _player.CurrentLobby = null;
        }
        
        #endregion
        
        #region CreateLobby
        
        private CreateLobbyOptions LobbyOptions(bool isPrivate, Unity.Services.Lobbies.Models.Player player, Dictionary<string, DataObject> data)
        {
            _lobbyOptionsBuilder = new LobbyOptionsBuilder().Reset();
            
            _lobbyOptionsBuilder.SetIsPrivate(isPrivate).SetPlayer(player).SetData(data);
            
            return _lobbyOptionsBuilder.Build();
        }

        public async void CreateLobby(string lobbyName = "New lobby", int maxPlayers = 6, bool isPrivate = false, Player player = null, Dictionary<string, DataObject> data = null)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, LobbyOptions(isPrivate, player.PlayerModel, data));
                SetLobbyData(lobby);
                
                Debug.Log(lobby.Name + $" lobby created with {lobby.MaxPlayers} max players. Lobby code: " + lobby.LobbyCode);
            }
            catch (LobbyServiceException e){ Debug.LogError(e); }
        }

        #endregion
        
        public async void DeleteLobby()
        {
            try
            {
                await Lobbies.Instance.DeleteLobbyAsync(_lobby.CurrentLobby.Id);
                Debug.Log($"Lobby {_lobby.CurrentLobby.Name} deleted");
                DeleteLobbyData();
            }
            catch (LobbyServiceException e){Debug.LogError(e);}
        }
        
        public async void JoinLobbyByCode(string code)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code);
                SetLobbyData(lobby);
                
                Debug.Log("Joined lobby with name " + lobby.Name);
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }

        public async void ExitLobby(string id)
        {
            if (_lobby.CurrentLobby == null) return;
            try
            {
                await Lobbies.Instance.RemovePlayerAsync(_lobby.CurrentLobby.Id, id);
                Debug.Log($"Exit from {_lobby.CurrentLobby.Name}");
                DeleteLobbyData();
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }
    }
}
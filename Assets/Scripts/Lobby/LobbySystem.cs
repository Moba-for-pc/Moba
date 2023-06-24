using System.Collections.Generic;
using Lobby.Interfaces;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using Zenject;

namespace Lobby
{
    public class LobbySystem : ILobbySystem, IFixedTickable
    {
        private Unity.Services.Lobbies.Models.Lobby _hostLobby;
        private float _heartbeatTimer;
        
        [Inject]
        private LobbySystem(Unity.Services.Lobbies.Models.Lobby hostLobby)
        {
            _hostLobby = hostLobby;
        }
        
        public void FixedTick() => HandleLobbyHeartbeat();

        public async void HandleLobbyHeartbeat()
        {
            if (_hostLobby == null) return;
        
            _heartbeatTimer -= Time.fixedDeltaTime;
            if (_heartbeatTimer <= 0f)
            {
                float heartbeatTimerMax = 15;
                _heartbeatTimer = heartbeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(_hostLobby.Id);
            }
        }

        public void PrintPlayers(Unity.Services.Lobbies.Models.Lobby lobby)
        {
            Debug.Log("Players in Lobby " + lobby.Name);
            foreach (Player player in lobby.Players)
            {
                Debug.Log("Player ID: " + player.Id + ", Player name: " + player.Data["PlayerName"].Value);
            }
        }

        public async void LobbiesList(QueryLobbiesOptions queryLobbiesOptions)
        {
            try
            {
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(queryLobbiesOptions);
            
                Debug.Log("Lobbies found: " + queryResponse.Results.Count);
                foreach (Unity.Services.Lobbies.Models.Lobby lobby in queryResponse.Results)
                {
                    Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
                }
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }
    }
}
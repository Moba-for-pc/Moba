using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.LobbyService
{
    public class LobbyPlayersList
    {
        private Lobby _lobby;

        public event Action<string, string> OnGetPlayers;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            lobbyService.OnCreateLobby += GetLobby;
            lobbyService.OnPlayerCountChange += GetListPlayers;
        }

        private void GetListPlayers()
        {
            Debug.Log("Players in Lobby " + _lobby.Name);
            foreach (Player player in _lobby.Players)
            {
                
                OnGetPlayers?.Invoke(player.Id, player.Name);
            }
        }

        private void GetLobby(Lobby lobby) => _lobby = lobby;
    }
}
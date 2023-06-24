using Lobby.Interfaces;
using UI.Lobby.Interfaces;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using Zenject;

namespace UI.Lobby
{
    public class LobbyPlayersPrinter : MonoBehaviour, IPlayersPrinter
    {
        private ILobbyService _lobbyService;
        private Unity.Services.Lobbies.Models.Lobby _hostLobby;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            _hostLobby = _lobbyService.GetHostLobby();
        }

        public void PrintPlayers()
        {
            Debug.Log("Players in Lobby " + _hostLobby.Name);
            foreach (Player player in _hostLobby.Players)
            {
                Debug.Log("Player ID: " + player.Id + ", Player name: " + player.Data["PlayerName"].Value);
            }
        }
    }
}
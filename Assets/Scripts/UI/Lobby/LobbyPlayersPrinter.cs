using Assets.Scripts.Lobby;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbyPlayersPrinter : MonoBehaviour, IPlayersPrinter
    {
        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        public void PrintPlayers()
        {
            Unity.Services.Lobbies.Models.
                Lobby currentLobby = _lobbyService.GetHostLobby();
            
            Debug.Log("Players in Lobby " + currentLobby.Name);
            foreach (Player player in currentLobby.Players)
            {
                Debug.Log("Player ID: " + player.Id + ", Player name: " + player.Data["PlayerName"].Value);
            }
        }
    }
}
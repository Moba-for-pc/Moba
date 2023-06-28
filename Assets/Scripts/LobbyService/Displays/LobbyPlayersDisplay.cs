using UnityEngine;
using Zenject;

namespace Assets.Scripts.LobbyService.Displays
{
    public class LobbyPlayersDisplay : MonoBehaviour
    {
        private Lobby _lobby;

        [Inject]
        private void Init(ILobbyService lobbyService) => lobbyService.OnPlayerCountChange += PrintPlayers;
        
        private void PrintPlayers()
        {
            Debug.Log("Players in Lobby " + _lobby.Name);
            foreach (Player player in _lobby.Players)
            {
                Debug.Log("Player ID: " + player.Id + ", Player name: " + player.Name);
            }
        }
    }
}
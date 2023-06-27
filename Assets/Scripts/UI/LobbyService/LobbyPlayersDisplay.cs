using Assets.Scripts.DTO;
using UnityEngine;
using Zenject;
using Player = Assets.Scripts.DTO.Player;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbyPlayersDisplay : MonoBehaviour
    {
        private Player _player;

        [Inject]
        private void Init(Player player) => _player = player;

        public void PrintPlayers()
        {
            Lobby currentLobby = _player.CurrentLobby;
            
            Debug.Log("Players in Lobby " + currentLobby.Name);
            foreach (Player player in currentLobby.Players)
            {
                Debug.Log("Player ID: " + player.Id + ", Player name: " + player.Name);
            }
        }
    }
}
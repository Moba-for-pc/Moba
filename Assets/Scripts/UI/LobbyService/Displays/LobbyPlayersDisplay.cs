using Assets.Scripts.LobbyService;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbyPlayersDisplay : MonoBehaviour
    {
        private LobbyPlayersList _playersList;
        
        [Inject]
        private void Init(LobbyPlayersList playersList) => _playersList = playersList;

        private void Start() => _playersList.OnGetPlayers += DisplayPlayers;
        
        private void DisplayPlayers(string id, string name)
        {
            Debug.Log($"Player ID: {id}, Player name: {name}");
        }
    }
}
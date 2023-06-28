using Assets.Scripts.LobbyService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class ExitLobbyButton : MonoBehaviour
    {
        private Button _exitLobbyButton;
        private ILobbyService _lobbyService;
        private Player _player;
        
        [Inject]
        private void Init(ILobbyService lobbyService) => _lobbyService = lobbyService;
        
        private void Start()
        {
            _exitLobbyButton = GetComponent<Button>();
            
            _exitLobbyButton.onClick.AddListener(() => _lobbyService.ExitLobby(_player.Id));
        }
    }
}
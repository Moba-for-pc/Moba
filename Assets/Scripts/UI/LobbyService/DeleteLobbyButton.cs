using Assets.Scripts.LobbyService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class DeleteLobbyButton : MonoBehaviour
    {
        private Button _deleteLobbyButton;
        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }
        
        private void Start()
        {
            TryGetComponent(out _deleteLobbyButton);
            
            _deleteLobbyButton.onClick.AddListener(_lobbyService.DeleteLobby);
        }
    }
}
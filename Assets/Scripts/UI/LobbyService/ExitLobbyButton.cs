using Assets.Scripts.DTO;
using Assets.Scripts.LobbyService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class ExitLobbyButton : MonoBehaviour
    {
        [SerializeField] private Button _exitLobbyButton;
        
        [Inject]
        private void Init(ILobbyService lobbyService, Player player) => _exitLobbyButton.onClick.AddListener(() => lobbyService.ExitLobby(player.Id));
    }
}
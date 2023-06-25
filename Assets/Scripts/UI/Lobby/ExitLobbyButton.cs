using Assets.Scripts.Lobby;
using UnityEngine;
using Unity.Services.Authentication;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Lobby
{
    public class ExitLobbyButton : MonoBehaviour
    {
        [SerializeField] private Button _exitLobbyButton;

        private ILobbyService _lobbyService;
        
        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            
            _exitLobbyButton.onClick.AddListener(ExitLobby);
        }
        
        private void ExitLobby() => _lobbyService.ExitLobby(AuthenticationService.Instance.PlayerId);
    }
}
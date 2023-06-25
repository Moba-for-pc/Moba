using Assets.Scripts.Lobby;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Lobby
{
    public class JoinLobbyButton : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _lobbyCode;
        [SerializeField] private Button _joinLobbyButton;
        
        private ILobbyService _lobbyService;
        
        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            
            _joinLobbyButton.onClick.AddListener(JoinLobby);
        }
        
        private void JoinLobby() => _lobbyService.JoinLobbyByCode(_lobbyCode.text);
    }
}
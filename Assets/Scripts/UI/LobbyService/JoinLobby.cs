using Assets.Scripts.LobbyService;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class JoinLobby : MonoBehaviour
    {
        private Button _joinLobbyButton;
        private TMP_InputField _lobbyCodeInput;
        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService) => _lobbyService = lobbyService;
        
        private void Start()
        {
            _joinLobbyButton = GetComponentInChildren<Button>();
            _lobbyCodeInput = GetComponentInChildren<TMP_InputField>();
            
            _joinLobbyButton.onClick.AddListener(() => _lobbyService.JoinLobbyByCode(_lobbyCodeInput.text));
        }
    }
}
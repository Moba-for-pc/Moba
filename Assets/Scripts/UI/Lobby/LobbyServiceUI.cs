using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ILobbyService = Assets.Scripts.Lobby.Interfaces.ILobbyService;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbyServiceUI : MonoBehaviour
    {
        [SerializeField] private Button _createNewLobbyButton;
        [SerializeField] private Button _deleteLobbyButton;
        [SerializeField] private TMP_InputField _lobbyName;
        [SerializeField] private TMP_InputField _maxPlayers;
        
        [SerializeField] private Button _joinLobbyButton;
        [SerializeField] private Button _exitLobbyButton;
        [SerializeField] private TMP_InputField _lobbyCode;
        
        private ILobbyService _lobbyService;
        
        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            
            _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
            _deleteLobbyButton.onClick.AddListener(_lobbyService.DeleteLobby);
            
            _joinLobbyButton.onClick.AddListener(JoinLobby);
            _exitLobbyButton.onClick.AddListener(ExitLobby);
        }

        private void CreateNewLobby()
        {
            int maxPlayers = int.Parse(_maxPlayers.text);
            
            _lobbyService.CreateLobby(_lobbyName.text, maxPlayers, new CreateLobbyOptions());
        }
        
        private void JoinLobby() => _lobbyService.JoinLobbyByCode(_lobbyCode.text);
        
        private void ExitLobby() => _lobbyService.ExitLobby(AuthenticationService.Instance.PlayerId);
    }
}

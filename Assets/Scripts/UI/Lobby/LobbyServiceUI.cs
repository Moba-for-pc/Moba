/*
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ILobbyService = Assets.Scripts.Lobby.ILobbyService;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbyServiceUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _lobbyNameInputField;
        [SerializeField] private TMP_InputField _maxPlayersInputField;
        [SerializeField] private Button _createNewLobbyButton;
        [SerializeField] private Button _deleteLobbyButton;

        [SerializeField] private TMP_InputField _lobbyCodeInputField;
        [SerializeField] private Button _joinLobbyByCodeButton;
        [SerializeField] private Button _joinLobbyByListButton;

        [SerializeField] private Button _exitLobbyButton;
        [SerializeField] private Button _kickLobbyButton;

        private ILobbyService _lobbyService;
        
        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            
            _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
            _deleteLobbyButton.onClick.AddListener(_lobbyService.DeleteLobby);
            
            _joinLobbyByCodeButton.onClick.AddListener(() => _lobbyService.JoinLobbyByCode(_lobbyCodeInputField.text));
            _joinLobbyByListButton.onClick.AddListener(JoinLobbyByList);
            
            _exitLobbyButton.onClick.AddListener(() => _lobbyService.ExitLobby(AuthenticationService.Instance.PlayerId));
            _kickLobbyButton.onClick.AddListener(KickLobby);
        }

        private void CreateNewLobby()
        {
            int maxPlayers = int.Parse(_maxPlayersInputField.text);
            
            _lobbyService.CreateLobby(_lobbyNameInputField.text, maxPlayers, new CreateLobbyOptions());
        }

        private void JoinLobbyByList()
        {
            
        }
        
        private void KickLobby()
        {
            
        }
    }
}
*/

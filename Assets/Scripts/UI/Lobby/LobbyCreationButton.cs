using TMPro;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ILobbyService = Assets.Scripts.Lobby.ILobbyService;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbyCreationButton : MonoBehaviour
    {
        [SerializeField] private Button _createNewLobbyButton;
        [SerializeField] private TMP_InputField _lobbyNameInputField;
        [SerializeField] private TMP_InputField _maxPlayersInputField;

        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;

            _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
        }

        private void CreateNewLobby()
        {
            int maxPlayers = int.Parse(_maxPlayersInputField.text);

            _lobbyService.CreateLobby(_lobbyNameInputField.text, maxPlayers, new CreateLobbyOptions());
        }
    }
}
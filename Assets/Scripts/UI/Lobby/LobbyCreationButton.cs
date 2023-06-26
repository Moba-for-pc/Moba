using TMPro;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
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
        private LobbyOptionsBuilderImp _lobbyOptionsBuilder;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
            _lobbyOptionsBuilder = new LobbyOptionsBuilderImp();

            _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
        }

        private void CreateNewLobby()
        {
            int maxPlayers = int.Parse(_maxPlayersInputField.text);
            CreateLobbyOptions lobbyOptions = _lobbyOptionsBuilder.BuildLobbyOptions();

            _lobbyService.CreateLobby(_lobbyNameInputField.text, maxPlayers, lobbyOptions);
        }
    }
}

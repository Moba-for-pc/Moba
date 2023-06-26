using TMPro;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builder;
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
            
            CreateLobbyOptions lobbyOptions = new CreateLobbyOptionsBuilder()
                .Reset()
                .SetIsPrivate(false)
                //.SetPlayer(None)
                //.SetData(None)
                .Build();

            
            _lobbyService.CreateLobby(_lobbyNameInputField.text, maxPlayers, lobbyOptions);
        }
    }
}

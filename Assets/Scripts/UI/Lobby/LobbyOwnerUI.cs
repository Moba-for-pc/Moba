using Lobby.Interfaces;
using TMPro;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Lobby
{
    public class LobbyOwnerUI : MonoBehaviour
    {
        [SerializeField] private Button _createNewLobbyButton;
        [SerializeField] private Button _deleteLobbyButton;
        [SerializeField] private TMP_InputField _lobbyName;
        [SerializeField] private TMP_InputField _maxPlayers;
        private ILobbyOwner _lobbyOwner;
        
        [Inject]
        private void Construct(ILobbyOwner lobbyOwner)
        {
            _lobbyOwner = lobbyOwner;
            _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
            _deleteLobbyButton.onClick.AddListener(_lobbyOwner.DeleteLobby);
        }

        private void CreateNewLobby()
        {
            int maxPlayers = int.Parse(_maxPlayers.text);
            
            _lobbyOwner.CreateLobby(_lobbyName.text, maxPlayers, new CreateLobbyOptions());
        }
    }
}

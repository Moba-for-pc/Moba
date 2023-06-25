using Assets.Scripts.Lobby;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.Lobby
{
    public class DeleteLobbyButton : MonoBehaviour
    {
        [SerializeField] private Button _deleteLobbyButton;

        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;

            _deleteLobbyButton.onClick.AddListener(_lobbyService.DeleteLobby);
        }
    }
}
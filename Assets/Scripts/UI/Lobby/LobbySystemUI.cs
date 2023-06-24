using Lobby.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Lobby
{
    public class LobbySystemUI : MonoBehaviour
    {
        [SerializeField] private Button _refreshButton;
        private ILobbySystem _lobbySystem;

        [Inject]
        private void Construct(ILobbySystem lobbySystem)
        {
            _lobbySystem = lobbySystem;
        }

        private void Start()
        {
            _refreshButton.onClick.AddListener(_lobbySystem.RefreshLobbiesList);
        }
    }
}
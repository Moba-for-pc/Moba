using Lobby.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Lobby
{
    public class LobbySystemUI : MonoBehaviour
    {
        [SerializeField] private Button _refreshButton;

        [Inject]
        private void Construct(ILobbySystem lobbySystem)
        {
            _refreshButton.onClick.AddListener(lobbySystem.RefreshLobbiesList);
        }
    }
}
using Lobby.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Lobby
{
    public class LobbyMemberUI : MonoBehaviour
    {
        [SerializeField] private Button _joinLobbyButton;
        [SerializeField] private Button _exitLobbyButton;
        [SerializeField] private TMP_InputField _lobbyCode;
        private ILobbyMember _lobbyMember;

        [Inject]
        private void Construct(ILobbyMember lobbyMember)
        {
            _lobbyMember = lobbyMember;
            _joinLobbyButton.onClick.AddListener(JoinLobby);
            _exitLobbyButton.onClick.AddListener(_lobbyMember.ExitLobby);
        }

        private void JoinLobby() => _lobbyMember.JoinLobbyByCode(_lobbyCode.text);
    }
}
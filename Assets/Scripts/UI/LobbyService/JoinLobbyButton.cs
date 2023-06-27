using Assets.Scripts.LobbyService;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class JoinLobbyButton : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _lobbyCodeInputField;
        [SerializeField] private Button _joinLobbyButton;
        
        [Inject]
        private void Init(ILobbyService lobbyService) => _joinLobbyButton.onClick.AddListener(() => lobbyService.JoinLobbyByCode(_lobbyCodeInputField.text));
    }
}
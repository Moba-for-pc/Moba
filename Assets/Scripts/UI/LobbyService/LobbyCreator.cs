using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ILobbyService = Assets.Scripts.LobbyService.ILobbyService;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbyCreator : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _lobbyNameInputField;
        [SerializeField] private TMP_InputField _maxPlayersInputField;
        
        private Button _createLobbyButton;
        private Toggle _isPrivateToggle;
        private ILobbyService _lobbyService;

        [Inject]
        private void Init(ILobbyService lobbyService) => _lobbyService = lobbyService;
        
        private void Start()
        {
            TryGetComponent(out _createLobbyButton);
            TryGetComponent(out _isPrivateToggle);
            
            _createLobbyButton.onClick.AddListener(() => _lobbyService.CreateLobby(
                _lobbyNameInputField.text,
                int.Parse(_maxPlayersInputField.text),
                _isPrivateToggle.isOn,
                null));
        }
    }
}

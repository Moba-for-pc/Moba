using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ILobbyService = Assets.Scripts.LobbyService.ILobbyService;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbyCreatorUi : MonoBehaviour
    {
        [SerializeField] private Button _createNewLobbyButton;
        [SerializeField] private TMP_InputField _lobbyNameInputField;
        [SerializeField] private TMP_InputField _maxPlayersInputField;
        [SerializeField] private Toggle _isPrivateToggle;
        
        [Inject]
        private void Init(ILobbyService lobbyService) =>
            _createNewLobbyButton.onClick.AddListener(() => lobbyService.CreateLobby(
                _lobbyNameInputField.text, 
                int.Parse(_maxPlayersInputField.text), 
                _isPrivateToggle.isOn));
    }
}

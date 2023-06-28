using Assets.Scripts.LobbyService.Displays;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbiesFilter : MonoBehaviour
    {
        private Button _saveButton;
        private TMP_InputField _countInputField;
        private ILobbiesDisplay _lobbiesDisplay;

        [Inject]
        private void Init(ILobbiesDisplay lobbiesDisplay) => _lobbiesDisplay = lobbiesDisplay;

        private void Start()
        {
            _saveButton = GetComponentInChildren<Button>();
            _countInputField = GetComponentInChildren<TMP_InputField>();
            
            _saveButton.onClick.AddListener(() => _lobbiesDisplay.FilterOptions(
                int.Parse(_countInputField.text)));
            
            _saveButton.onClick.AddListener(_lobbiesDisplay.DisplayLobbies);
        }
    }
}
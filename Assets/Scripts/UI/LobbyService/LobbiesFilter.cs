using Assets.Scripts.LobbyService;
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
        private ILobbiesList _lobbiesList;

        [Inject]
        private void Init(ILobbiesList lobbiesList) => _lobbiesList = lobbiesList;

        private void Start()
        {
            TryGetComponent(out _saveButton);
            TryGetComponent(out _countInputField);
            
            _saveButton.onClick.AddListener(() => _lobbiesList.FilterOptions(
                int.Parse(_countInputField.text)));
            
            _saveButton.onClick.AddListener(_lobbiesList.GetLobbies);
        }
    }
}
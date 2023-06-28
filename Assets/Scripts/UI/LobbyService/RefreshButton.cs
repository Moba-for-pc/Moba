using Assets.Scripts.LobbyService.Displays;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class RefreshButton : MonoBehaviour
    {
        private Button _refreshButton;
        private ILobbiesDisplay _lobbiesDisplay;

        [Inject]
        private void Init(ILobbiesDisplay lobbiesDisplay) => _lobbiesDisplay = lobbiesDisplay;

        private void Start()
        {
            _refreshButton = GetComponentInChildren<Button>();
            
            _refreshButton.onClick.AddListener(_lobbiesDisplay.DisplayLobbies);
        }
    }
}
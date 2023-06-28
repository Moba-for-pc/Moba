using Assets.Scripts.LobbyService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class RefreshButton : MonoBehaviour
    {
        private Button _refreshButton;
        private ILobbiesList _lobbiesList;

        [Inject]
        private void Init(ILobbiesList lobbiesList) => _lobbiesList = lobbiesList;

        private void Start()
        {
            TryGetComponent(out _refreshButton);
            
            _refreshButton.onClick.AddListener(_lobbiesList.GetLobbies);
        }
    }
}
using Assets.Scripts.LobbyService;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbiesDisplay : MonoBehaviour
    {
        private ILobbiesList _lobbiesList;
        
        [Inject]
        private void Init(ILobbiesList lobbiesList) => _lobbiesList = lobbiesList;

        private void Start() => _lobbiesList.OnGetLobbies += DisplayLobbies;
        
        private void DisplayLobbies(string name, int maxPlayer)
        {
            Debug.Log($"{name}, max players {maxPlayer}");
        }
    }
}
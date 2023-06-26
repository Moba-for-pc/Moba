using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbiesDisplay : MonoBehaviour, ILobbiesDisplay
    {
        [SerializeField] private Button _refreshButton;
        private QueryLobbiesOptions _lobbiesOptions;
        private QueryLobbiesOptionsBuilderImp _queryLobbiesOptions;

        private void Start()
        {
            _refreshButton.onClick.AddListener(DisplayLobbies);
        }
        
        public async void DisplayLobbies()
        {
            try
            {
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(_lobbiesOptions);
            
                Debug.Log("Lobbies found: " + queryResponse.Results.Count);
                foreach (Unity.Services.Lobbies.Models.Lobby lobby in queryResponse.Results)
                {
                    Debug.Log($"{lobby.Name}, max players {lobby.MaxPlayers}");
                }
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        public void FilterOptions()// Didnt get around to do or think something here
        {
            _queryLobbiesOptions = new QueryLobbiesOptionsBuilderImp();
        }
    }
}
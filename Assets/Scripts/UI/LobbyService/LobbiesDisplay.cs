using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.LobbyService
{
    public class LobbiesDisplay : MonoBehaviour
    {
        [SerializeField] private Button _refreshButton;
        private QueryLobbiesOptionsBuilder _queryLobbiesOptions;

        private void Start()
        {
            _refreshButton.onClick.AddListener(DisplayLobbies);
        }
        
        private async void DisplayLobbies()
        {
            try
            {
                QueryLobbiesOptions lobbiesFilter = FilterOptions();
                
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(lobbiesFilter);
            
                Debug.Log("Lobbies found: " + queryResponse.Results.Count);
                foreach (Lobby lobby in queryResponse.Results)
                {
                    Debug.Log($"{lobby.Name}, max players {lobby.MaxPlayers}");
                }
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }

        private QueryLobbiesOptions FilterOptions()
        {
            _queryLobbiesOptions = new QueryLobbiesOptionsBuilder().SetCount(5);
            return _queryLobbiesOptions.Build();
        }
    }
}
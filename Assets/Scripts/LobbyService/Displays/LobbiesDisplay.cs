using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Assets.Scripts.LobbyService.Displays
{
    public class LobbiesDisplay : MonoBehaviour, ILobbiesDisplay
    {
        private QueryLobbiesOptions _queryLobbiesOptions;
        
        public async void DisplayLobbies()
        {
            try
            {
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(_queryLobbiesOptions);
            
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

        public void FilterOptions(int count)
        {
            QueryLobbiesOptionsBuilder queryLobbiesOptions = new QueryLobbiesOptionsBuilder().Reset();
            queryLobbiesOptions.SetCount(count);
            
            _queryLobbiesOptions = queryLobbiesOptions.Build();
        }
    }
}
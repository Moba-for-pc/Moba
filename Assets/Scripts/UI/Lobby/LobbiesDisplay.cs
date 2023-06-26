using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builder;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Lobby
{
    public class LobbiesDisplay : MonoBehaviour, ILobbiesPrinter
    {
        [SerializeField] private Button _refreshButton;
        private QueryLobbiesOptions _queryLobbiesOptions;

        private void Start()
        {
            _refreshButton.onClick.AddListener(PrintLobbies);
        }
        
        public async void PrintLobbies()
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

        public void FilterOptions()
        {
            _queryLobbiesOptions = new QueryLobbiesOptionsBuilder()
                .Reset()
                .SetCount(20)
                //.SetSkip(None)
                //.SetSampleResults(None)
                //.SetFilters(None)
                //.SetOrder(None)
                //.SetContinuationToken(None)
                .Build();
        }
    }
}
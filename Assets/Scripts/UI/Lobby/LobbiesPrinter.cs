using System.Collections.Generic;
using UI.Lobby.Interfaces;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby
{
    public class LobbiesPrinter : MonoBehaviour, ILobbiesPrinter
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
            _queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 10,
                //Skip = 5,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                },
                Order = new List<QueryOrder>
                {
                    new QueryOrder(false, QueryOrder.FieldOptions.Created)
                }
            };
        }
    }
}
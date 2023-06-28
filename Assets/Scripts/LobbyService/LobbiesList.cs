using System;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Builders;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Assets.Scripts.LobbyService
{
    public class LobbiesList : ILobbiesList
    {
        private QueryLobbiesOptions _queryLobbiesOptions;

        public event Action<string, int> OnGetLobbies;
        
        public async void GetLobbies()
        {
            try
            {
                QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync(_queryLobbiesOptions);
            
                Debug.Log("Lobbies found: " + queryResponse.Results.Count); 
                foreach (Unity.Services.Lobbies.Models.Lobby lobby in queryResponse.Results)
                    OnGetLobbies?.Invoke(lobby.Name, lobby.MaxPlayers);
            }
            catch (LobbyServiceException e) { Debug.Log(e); }
        }

        public void FilterOptions(int count)
        {
            QueryLobbiesOptionsBuilder queryLobbiesOptions = new QueryLobbiesOptionsBuilder();
            queryLobbiesOptions.SetCount(count);
            
            _queryLobbiesOptions = queryLobbiesOptions.Build();
        }
    }
}
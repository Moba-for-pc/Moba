using Lobby.Interfaces;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Lobby
{
    public class LobbyOwner : ILobbyOwner
    {
        private Unity.Services.Lobbies.Models.Lobby _hostLobby;

        public async void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions)
        {
            try
            {
                Unity.Services.Lobbies.Models.Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);
                _hostLobby = lobby;
                Debug.Log(lobby.Name + $" lobby created with {lobby.MaxPlayers} max players. Lobby code: " + lobby.LobbyCode);
            }
            catch (LobbyServiceException e){Debug.LogError(e);}
        }

        public async void DeleteLobby()
        {
            try
            {
                await Lobbies.Instance.DeleteLobbyAsync(_hostLobby.Id);
                Debug.Log($"Lobby {_hostLobby.Name} deleted");
            }
            catch (LobbyServiceException e){Debug.LogError(e);}
        }

        public async void RemovePlayer(Player player)
        {
            try
            {
                await Lobbies.Instance.RemovePlayerAsync(_hostLobby.Id, player.Id);
                Debug.Log($"Player {player.Data["PlayerName"].Value} remove from {_hostLobby.Name}");
            }
            catch (LobbyServiceException e) { Debug.LogError(e); }
        }
        
        public Unity.Services.Lobbies.Models.Lobby GetHostLobby(){return _hostLobby;} 
    }
}
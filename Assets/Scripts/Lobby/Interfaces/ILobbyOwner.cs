using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

namespace Lobby.Interfaces
{
    public interface ILobbyOwner
    {
        void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions);
        void DeleteLobby();
        void RemovePlayer(Player player);
        Unity.Services.Lobbies.Models.Lobby GetHostLobby();
    }
}
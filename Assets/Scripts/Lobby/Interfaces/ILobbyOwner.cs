using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

namespace Assets.Scripts.Lobby.Interfaces
{
    public interface ILobbyOwner
    {
        void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions);
        void DeleteLobby(Unity.Services.Lobbies.Models.Lobby lobby);
        void RemovePlayer(Player player);
    }
}
using Unity.Services.Lobbies;

namespace Lobby.Interfaces
{
    public interface ILobbySystem
    {
        void HandleLobbyHeartbeat();
        void PrintPlayers(Unity.Services.Lobbies.Models.Lobby lobby);
        void LobbiesList(QueryLobbiesOptions queryLobbiesOptions);
    }
}
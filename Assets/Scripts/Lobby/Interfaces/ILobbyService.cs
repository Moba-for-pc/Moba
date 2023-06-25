using Unity.Services.Lobbies;

namespace Lobby.Interfaces
{
    public interface ILobbyService
    {
        void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions);
        void KickPlayer();
        void DeleteLobby();
        void JoinLobbyByCode(string code);
        void ExitLobby(string id);
        Unity.Services.Lobbies.Models.Lobby GetHostLobby();
    }
}
using Unity.Services.Lobbies;

namespace Assets.Scripts.Lobby
{
    public interface ILobbyService
    {
        void CreateLobby(string lobbyName, int maxPlayers, CreateLobbyOptions createLobbyOptions);
        void DeleteLobby();
        void JoinLobbyByCode(string code);
        void ExitLobby(string id);
        Unity.Services.Lobbies.Models.Lobby GetHostLobby();
    }
}
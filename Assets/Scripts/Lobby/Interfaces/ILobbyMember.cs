namespace Lobby.Interfaces
{
    public interface ILobbyMember
    {
        void JoinLobbyByCode(string code);
        void ExitLobby(Unity.Services.Lobbies.Models.Lobby lobby);
    }
}
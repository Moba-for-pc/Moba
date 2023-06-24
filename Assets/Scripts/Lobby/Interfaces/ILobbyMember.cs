namespace Lobby.Interfaces
{
    public interface ILobbyMember
    {
        void JoinLobbyByCode(string code);
        void ExitLobby();
    }
}
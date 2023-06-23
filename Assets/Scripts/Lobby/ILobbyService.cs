using Unity.Services.Lobbies.Models;

public interface ILobbyService
{
    public void CreateLobby(string lobbyName, int maxPlayers);
    public void JoinLobbyByCode(string lobbyCode);
    public void GetLobbiesList();
    public void PrintPlayers(Lobby lobby);
}
public interface ILobbyProvider
{
    public void ConnectToLobby(string lobbyCode);
    public void GetLobbies(string lobbyName, int maxPlayers);
    
}

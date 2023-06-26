namespace Unity.Services.Lobbies.Builders
{
    public class LobbyOptionsBuilderImp
    {
        public CreateLobbyOptions BuildLobbyOptions()
        {
            CreateLobbyOptions lobbyOptions = new LobbyOptionsBuilder()
                .SetIsPrivate(false)
                //.SetPlayer(None)
                //.SetData(None)
                .Build();

            return lobbyOptions;
        }
    }
}
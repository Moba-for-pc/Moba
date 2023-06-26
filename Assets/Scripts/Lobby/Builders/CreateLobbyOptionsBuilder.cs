using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Builders
{
    public class LobbyOptionsBuilder
    {
        private CreateLobbyOptions _lobbyOptions;

        public LobbyOptionsBuilder()
        {
            _lobbyOptions = new CreateLobbyOptions();
        }

        public LobbyOptionsBuilder SetIsPrivate(bool? isPrivate)
        {
            _lobbyOptions.IsPrivate = isPrivate;
            return this;
        }

        public LobbyOptionsBuilder SetPlayer(Player player)
        {
            _lobbyOptions.Player = player;
            return this;
        }

        public LobbyOptionsBuilder SetData(Dictionary<string, DataObject> data)
        {
            _lobbyOptions.Data = data;
            return this;
        }
        public LobbyOptionsBuilder Reset()
        {
            _lobbyOptions = new CreateLobbyOptions();
            return this;
        }

        public CreateLobbyOptions Build()
        {
            return _lobbyOptions;
        }
    }
}
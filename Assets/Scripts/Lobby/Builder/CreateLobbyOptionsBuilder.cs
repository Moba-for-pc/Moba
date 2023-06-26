using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Unity.Services.Lobbies.Builder
{
    public class CreateLobbyOptionsBuilder
    {
        private CreateLobbyOptions _lobbyOptions;

        public CreateLobbyOptionsBuilder()
        {
            _lobbyOptions = new CreateLobbyOptions();
        }

        public CreateLobbyOptionsBuilder SetIsPrivate(bool? isPrivate)
        {
            _lobbyOptions.IsPrivate = isPrivate;
            return this;
        }

        public CreateLobbyOptionsBuilder SetPlayer(Player player)
        {
            _lobbyOptions.Player = player;
            return this;
        }

        public CreateLobbyOptionsBuilder SetData(Dictionary<string, DataObject> data)
        {
            _lobbyOptions.Data = data;
            return this;
        }
        public CreateLobbyOptionsBuilder Reset()
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
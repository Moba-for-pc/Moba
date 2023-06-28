using System;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;

namespace Assets.Scripts.LobbyService
{
    public interface ILobbyService
    {
        public event Action<Lobby> OnCreateLobby;
        public event Action OnPlayerCountChange;

        void CreateLobby(string lobbyName, int maxPlayers, bool isPrivate, Dictionary<string, DataObject> data);
        void DeleteLobby();
        void JoinLobbyByCode(string code);
        void ExitLobby(string id);
    }
}
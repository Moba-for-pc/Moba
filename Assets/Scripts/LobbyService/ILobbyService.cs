using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using Player = Assets.Scripts.DTO.Player;

namespace Assets.Scripts.LobbyService
{
    public interface ILobbyService
    {
        void CreateLobby(string lobbyName = "New lobby", int maxPlayers = 6, bool isPrivate = false, Player player = null, Dictionary<string, DataObject> data = null);
        void DeleteLobby();
        void JoinLobbyByCode(string code);
        void ExitLobby(string id);
    }
}
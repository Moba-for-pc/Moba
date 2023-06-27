using System.Collections.Generic;

namespace Assets.Scripts.DTO
{
    public class Lobby
    {
        public Unity.Services.Lobbies.Models.Lobby CurrentLobby;
        public string Name;
        public string Id;
        public string HostId;
        public List<Player> Players;
    }
}
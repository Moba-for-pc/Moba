using System.Collections.Generic;

namespace Assets.Scripts.LobbyService
{
    public class Lobby
    {
        public string Name;
        public string Id;
        public string HostId;
        public List<Player> Players;
    }
}
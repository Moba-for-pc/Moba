using Assets.Scripts.Database.Models;
using System.Threading.Tasks;

namespace Assets.Scripts.Database.Repositories
{
    public interface IPlayerRepository
    {
        public Task<Player> GetCurrentPlayerAsync();
        public Task<Player> GetPlayerByIdAsync(string id);
        public Task UpdateCurrentPlayerAsync(Player player);
    }
}

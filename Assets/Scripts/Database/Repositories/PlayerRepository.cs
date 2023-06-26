using Assets.Scripts.Authentication;
using Assets.Scripts.Database.Models;
using Assets.Scripts.UnityService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;

namespace Assets.Scripts.Database.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        IUnityService _unityServices;
        IAuthenticator _authenticator;
        public PlayerRepository(IUnityService unityService, IAuthenticator authenticator) 
        {
            _unityServices = unityService;
            _authenticator = authenticator;

            _unityServices.InitIfNeededAsync();
        }
        public async Task<Player> GetCurrentPlayerAsync()
        {
            
            var data = await CloudSaveService.Instance.Data.LoadAllAsync();
            var player = new Player()
            {
                Name = data[nameof(Player.Name)]
            };
            return player;
        }

        public async Task<Player> GetPlayerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCurrentPlayerAsync(Player player)
        {
            var playerKeys = new HashSet<string>() {
                nameof(Player.Name),
            };
            var keysInDb = await CloudSaveService.Instance.Data.RetrieveAllKeysAsync();
            foreach(var key in keysInDb)
            {
                if(!playerKeys.Contains(key))
                    await CloudSaveService.Instance.Data.ForceDeleteAsync(key);
            }

            var newData = new Dictionary<string, object>() {
                {nameof(Player.Name), player.Name},
            };
            await CloudSaveService.Instance.Data.ForceSaveAsync(newData);
        }
    }
}

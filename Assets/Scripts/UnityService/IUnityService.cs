using System;
using System.Threading.Tasks;
using Unity.Services.Core;

namespace Assets.Scripts.UnityService
{
    public interface IUnityService
    {
        public event Action ServicesInitialized;
        public Task InitIfNeededAsync();
        public Task ReInitWithOptionsAsync(InitializationOptions username);
    }
}

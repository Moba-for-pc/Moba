using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;

namespace Assets.Scripts.UnityService
{
    public class UnityServiceImpl : IUnityService
    {
        public async Task InitIfNeededAsync()
        {
            if (UnityServices.State == ServicesInitializationState.Initialized)
                return;

            await UnityServices.InitializeAsync();
        }

        public async Task ReInitWithOptionsAsync(InitializationOptions options)
        {
            await UnityServices.InitializeAsync(options);
            Debug.Log("Unity services re-initialized with options");
        }
    }
}

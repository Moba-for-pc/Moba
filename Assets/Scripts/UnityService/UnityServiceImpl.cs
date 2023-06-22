using Unity.Services.Core;

namespace Assets.Scripts.UnityService
{
    public class UnityServiceImpl : IUnityService
    {
        public async void InitIfNeeded()
        {
            if (UnityServices.State == ServicesInitializationState.Initialized)
                return;

            await UnityServices.InitializeAsync();
        }

        public async void ReInitWithOptions(InitializationOptions options)
        {
            await UnityServices.InitializeAsync(options);
        }
    }
}

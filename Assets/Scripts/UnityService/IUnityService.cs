using Unity.Services.Core;

namespace Assets.Scripts.UnityService
{
    public interface IUnityService
    {
        public void InitIfNeeded();

        public void ReInitWithOptions(InitializationOptions username);
    }
}

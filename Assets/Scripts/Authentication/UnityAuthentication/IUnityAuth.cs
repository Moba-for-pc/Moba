namespace Assets.Scripts.Authentication.UnityAuthentication
{
    public interface IUnityAuth : IAuthenticationProvider
    {
        public void Authenticate(string token);
    }
}

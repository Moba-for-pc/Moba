namespace Assets.Scripts.Authentication
{
    public interface IAuthenticator
    {
        public string GetUserId();
        public bool IsAuthenticated();
    }
}
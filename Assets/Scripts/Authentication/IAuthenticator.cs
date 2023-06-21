using System;

public interface IAuthenticator
{
    public event Action AuthenticationRequested;
    public string GetUserId();
    public bool IsAuthenticated();
    public void Authenticate();
}
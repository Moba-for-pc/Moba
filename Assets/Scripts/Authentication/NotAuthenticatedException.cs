using System;

public class NotAuthenticatedException : Exception
{
    public NotAuthenticatedException(string message) : base(message)
    {

    }
}

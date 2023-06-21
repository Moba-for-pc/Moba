using System;

namespace Assets.Scripts.Authentication
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string message) : base(message)
        {

        }
    }
}
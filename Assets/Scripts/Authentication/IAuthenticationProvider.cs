using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Authentication
{
    public interface IAuthenticationProvider
    {
        public string GetUserId();
        public void Authenticate();
        public bool IsAuthenticated();
    }
}
using Assets.Scripts.Authentication.GuestAuthentication;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Authentication
{
    public class GuestAuthButton : MonoBehaviour
    {
        private IGuestAuth _guestAuth;

        [Inject]
        public void Init(IGuestAuth guestAuth)
        {
            _guestAuth = guestAuth;
        }

        public async void Auth()
        {
            await _guestAuth.AuthenticateAsync();
        }
    }
}
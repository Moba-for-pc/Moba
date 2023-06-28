using System;

namespace Assets.Scripts.LobbyService
{
    public interface ILobbiesList
    {
        public event Action<string, int> OnGetLobbies;
        
        void GetLobbies();
        void FilterOptions(int count);
    }
}
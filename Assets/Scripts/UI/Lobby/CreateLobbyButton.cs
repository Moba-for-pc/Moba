using Assets.Scripts.UnityService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreateLobbyButton : MonoBehaviour
{
    [SerializeField] private Button _createNewLobbyButton;
    [SerializeField] private Button _joinLobbyButton;
    [SerializeField] private TMP_InputField _lobbyName;
    [SerializeField] private TMP_InputField _maxPlayers;
    [SerializeField] private TMP_InputField _lobbyCode;
    
    private ILobbyService _lobbyService;

    [Inject]
    public void Init(ILobbyService lobbyService, IUnityService service)
    {
        _lobbyService = lobbyService;
        service.InitIfNeededAsync();//
    }

    private void Awake()
    {
        _createNewLobbyButton.onClick.AddListener(CreateNewLobby);
        _joinLobbyButton.onClick.AddListener(JoinLobby);
    }

    private void CreateNewLobby()
    {
        int maxPlayers = int.Parse(_maxPlayers.text);
        _lobbyService.CreateLobby(_lobbyName.text, maxPlayers);

    }
    private void JoinLobby()
    {
        _lobbyService.JoinLobbyByCode(_lobbyCode.text);
    }
}

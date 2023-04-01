using Controllers;
using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{

    [Header("Scene Objects")] 
    [SerializeField] private Transform _placeForUi;

    private ProfilePlayers _profilePlayer;

    private MainController _mainController;


    private void Start()
    {
        GetState();
        _mainController = new MainController(_profilePlayer, _placeForUi);

    }

    private void GetState()
    {
        if (PlayerPrefs.HasKey(KeyConst.Key))
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                _profilePlayer = new ProfilePlayers(GameState.WebView);
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                _profilePlayer = new ProfilePlayers(GameState.WebView);
            }
            _profilePlayer = new ProfilePlayers(GameState.LackInternet);
        }
        _profilePlayer = new ProfilePlayers(GameState.GetConfig);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }

}

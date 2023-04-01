using Profile;
using UnityEngine;

namespace Controllers
{
    public class MainController : BaseController
    {
        private ProfilePlayers _profilePlayer;
        private Transform _placeForUi;
        private FirebaseController _firebaseController;
        private WebViewController _webViewController;

        public MainController(ProfilePlayers profilePlayer, Transform placeForUi)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;

            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void OnChangeGameState(GameState state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameState.GetConfig:
                    _firebaseController = new FirebaseController(_profilePlayer);
                    break;
                case GameState.WebView:
                    _webViewController = new WebViewController(_profilePlayer, _placeForUi);
                    break;
                   
            }
        }

        private void DisposeControllers()
        {
           


        }
    }
}
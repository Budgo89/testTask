using Profile;
using UnityEngine;

namespace Controllers
{
    public class WebViewController : BaseController
    {
        private readonly ProfilePlayers _profilePlayer;
        private readonly Transform _placeForUi;

        public WebViewController(ProfilePlayers profilePlayer, Transform placeForUi)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
        }
    }
}
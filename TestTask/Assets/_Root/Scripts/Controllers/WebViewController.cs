using Profile;
using Tool;
using UnityEngine;

namespace Controllers
{
    public class WebViewController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("UniWebViewVariant");
        
        private readonly ProfilePlayers _profilePlayer;
        private readonly Transform _placeForUi;
        private UniWebView _uniWebView;
        

        public WebViewController(ProfilePlayers profilePlayer, Transform placeForUi)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            
            _uniWebView = LoadView(placeForUi);
            
            if (PlayerPrefs.HasKey(KeyConst.Key))
            {
                _uniWebView. Load(PlayerPrefs.GetString(KeyConst.Key));
                _uniWebView.Show(true);
            }
            
        }

        private UniWebView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<UniWebView>();
        }
    }
}
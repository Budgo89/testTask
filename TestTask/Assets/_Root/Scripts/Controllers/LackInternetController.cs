using Controllers;
using DefaultNamespace;
using Tool;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root.Scripts.Controllers
{
    public class LackInternetController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("LackInternet");
        
        private readonly Transform _placeForUi;
        private LackInternetView _lackInternetView;

        public LackInternetController(Transform placeForUi)
        {
            _placeForUi = placeForUi;
            
            _lackInternetView = LoadView(placeForUi);

            AddButton();
        }

        private void AddButton()
        {
            _lackInternetView.ButtonOk.onClick.AddListener(OnButtonOkClick);
        }
        
        private void OnButtonOkClick() => SceneManager.LoadScene(0);

        private LackInternetView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<LackInternetView>();
        }
    }
}
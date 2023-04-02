using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using UnityEngine.UI;

namespace Controllers
{
    public class FormsController : BaseController
    {
        private readonly MainView _mainView;
        private readonly List<FormsView> _formsViews;
        private readonly FormsColorModel _formsColorModel;
        private Button _forwardButton;
        private Button _backButton;

        public FormsController(MainView mainView, List<FormsView> formsViews, FormsColorModel formsColorModel)
        {
            _mainView = mainView;
            _formsViews = formsViews;
            _formsColorModel = formsColorModel;
            AddButton();
            SubscribeButton();
        }

        private void AddButton()
        {
            _forwardButton = _mainView.ForwardButton;
            _backButton = _mainView.BackButton;
        }

        private void SubscribeButton()
        {
            _forwardButton.onClick.AddListener(() => WillСhange(1));
            _backButton.onClick.AddListener(() => WillСhange(-1));
        }

        private void WillСhange(int id)
        {
            if (_formsColorModel.Id + id > _formsViews.Count - 1 || _formsColorModel.Id + id < 0)
                return;
            _formsColorModel.Id += id;
            foreach (var formsView in _formsViews)
            {
                formsView.gameObject.SetActive(false);
            }
            _formsViews.Find(x=> x.ID == _formsColorModel.Id).gameObject.SetActive(true);
        }
        
        protected override void OnDispose()
        {
            UnsubscribeButton();
        }

        private void UnsubscribeButton()
        {
            _forwardButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }
    }
}
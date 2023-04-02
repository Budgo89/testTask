using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class NextControllerStage1 : BaseController
    {
        private readonly MainView _mainView;
        private readonly List<FormsView> _formsViews;
        private readonly FormsColorModel _formsColorModel;
        private readonly ProfilePlayersPlug _profilePlayers;
        
        private Button _nextButton;

        public NextControllerStage1(MainView mainView, List<FormsView> formsViews, FormsColorModel formsColorModel, ProfilePlayersPlug profilePlayers)
        {
            _mainView = mainView;
            _formsViews = formsViews;
            _formsColorModel = formsColorModel;
            _profilePlayers = profilePlayers;
            
            AddButton();
            SubscribeButton();
        }

        private void AddButton()
        {
            _nextButton = _mainView.NextButton;
        }

        private void SubscribeButton()
        {
            _nextButton.onClick.AddListener(OnNextButtonClick);
        }

        private void OnNextButtonClick()
        {
            _formsViews.Find(x=>x.ID == _formsColorModel.Id).Animators.SetBool("isAmimStart", true);
            _profilePlayers.CurrentState.Value = GameStatePlug.Stage2;
        }

        protected override void OnDispose()
        {
            Save();
            UnsubscribeButton();
        }

        private void Save()
        {
            PlayerPrefs.SetString(ConstSave.Form, JsonUtility.ToJson(_formsColorModel));
        }

        private void UnsubscribeButton()
        {
            _nextButton.onClick.RemoveAllListeners();
        }
    }
}
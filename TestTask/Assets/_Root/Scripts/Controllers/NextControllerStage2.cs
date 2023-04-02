using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class NextControllerStage2 : BaseController
    {
        private readonly MainView _mainView;
        private readonly List<FormsView> _logosViews;
        private readonly FormsColorModel _logoColorModel;
        private readonly ProfilePlayersPlug _profilePlayers;
        
        private Button _nextButton;

        public NextControllerStage2(MainView mainView, List<FormsView> logosViews, FormsColorModel logoColorModel, ProfilePlayersPlug profilePlayers)
        {
            _mainView = mainView;
            _logosViews = logosViews;
            _logoColorModel = logoColorModel;
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
            _logosViews.Find(x=>x.ID == _logoColorModel.Id).Animators.SetBool("IsLogoNext", true);
            _profilePlayers.CurrentState.Value = GameStatePlug.Stage3;
        }
        protected override void OnDispose()
        {
            Save();
            _nextButton.onClick.RemoveAllListeners();
        }
        private void Save()
        {
            PlayerPrefs.SetString(ConstSave.Logo, JsonUtility.ToJson(_logoColorModel));
        }
    }
}
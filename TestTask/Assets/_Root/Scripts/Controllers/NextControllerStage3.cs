using DefaultNamespace;
using DefaultNamespace.Models;
using Profile;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class NextControllerStage3 : BaseController
    {
        private readonly MainView _mainView;
        private readonly NameModel _nameModel;
        private readonly ProfilePlayersPlug _profilePlayers;

        private Button _nextButton;

        public NextControllerStage3(MainView mainView, NameModel nameModel, ProfilePlayersPlug profilePlayers)
        {
            _mainView = mainView;
            _nameModel = nameModel;
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
            _nameModel.Name = _mainView.TeamName.text;
            _profilePlayers.CurrentState.Value = GameStatePlug.Stage4;
        }


        protected override void OnDispose()
        {
            Save();
            _nextButton.onClick.RemoveAllListeners();
        }
        private void Save()
        {
            PlayerPrefs.SetString(ConstSave.Name, JsonUtility.ToJson(_nameModel));
        }
    }
}
using System.Collections.Generic;
using Controllers;
using DefaultNamespace;
using DefaultNamespace.Models;
using Profile;
using UnityEngine;

namespace DControllers
{
    public class MainControllerPlug : BaseController
    {
        private readonly MainView _mainView;
        private readonly List<FormsView> _forms;
        private readonly FormsColorModel _formsColorModel;
        private readonly List<FormsView> _logos;
        private readonly FormsColorModel _logosColorModel;
        private readonly ProfilePlayersPlug _profilePlayers;
        private readonly NameModel _nameModel;

        private List<FormsView> _formsViews;
        private List<FormsView> _logosViews;
        private FormsController _formsController;
        private ColorController _colorController;
        private NextControllerStage1 _nextControllerStage1;
        private StartStage2Controller _startStage2Controller;
        private NextControllerStage2 _nextControllerStage2;
        private StartStage3Controller _startStage3Controller;
        private InputFieldController _inputFieldController;
        private NextControllerStage3 _nextControllerStage3;

        public MainControllerPlug(MainView mainView, List<FormsView> forms, FormsColorModel formsColorModel,
            List<FormsView> logos,
            FormsColorModel logosColorModel,
            ProfilePlayersPlug profilePlayers, NameModel nameModel)
        {
            _mainView = mainView;
            _forms = forms;
            _formsColorModel = formsColorModel;
            _logos = logos;
            _logosColorModel = logosColorModel;
            _profilePlayers = profilePlayers;
            _nameModel = nameModel;

            _formsViews = new List<FormsView>();
            _logosViews = new List<FormsView>();
            
            profilePlayers.CurrentState.SubscribeOnChange(OnChangeGameState);
            AddForms();
            AddLogo();
            OnChangeGameState(_profilePlayers.CurrentState.Value);
        }

        private void AddLogo()
        {
            foreach (var logo in _logos)
            {
                var logoObject = Object.Instantiate(logo, _mainView.Container);
                logoObject.Type0layer0.color = _logosColorModel._type0layer0;
                logoObject.Type0layer1.color = _logosColorModel._type0layer1;
                logoObject.Type0layer2.color = _logosColorModel._type0layer2;
                _logosViews.Add(logoObject);
                logoObject.gameObject.SetActive(false);
            }
        }

        private void AddForms()
        {
            foreach (var form in _forms)
            {
                var formObject = Object.Instantiate(form, _mainView.Container);
                formObject.Type0layer0.color = _formsColorModel._type0layer0;
                formObject.Type0layer1.color = _formsColorModel._type0layer1;
                formObject.Type0layer2.color = _formsColorModel._type0layer2;
                _formsViews.Add(formObject);
                formObject.gameObject.SetActive(false);
            }
            _formsViews.Find(x => x.ID == _formsColorModel.Id).gameObject.SetActive(true);
        }
        
        private void OnChangeGameState(GameStatePlug state)
        {
            DisposeControllers();
            switch (state)
            {
                case GameStatePlug.Stage1:
                    _formsController = new FormsController(_mainView, _formsViews, _formsColorModel);
                    _colorController = new ColorController(_mainView, _formsViews, _formsColorModel);
                    _nextControllerStage1 = new NextControllerStage1(_mainView, _formsViews, _formsColorModel, _profilePlayers);
                    break;
                case GameStatePlug.Stage2:
                    _startStage2Controller = new StartStage2Controller(_mainView, _forms, _logosViews, _formsColorModel, _logosColorModel  );
                    _formsController = new FormsController(_mainView, _logosViews, _logosColorModel);
                    _colorController = new ColorController(_mainView, _logosViews, _logosColorModel);
                    _nextControllerStage2 = new NextControllerStage2(_mainView, _logosViews, _logosColorModel, _profilePlayers);
                    break;               
                case GameStatePlug.Stage3:
                    _startStage3Controller = new StartStage3Controller(_forms, _logos, _mainView, _formsColorModel, _logosColorModel, _nameModel);
                    _inputFieldController = new InputFieldController(_mainView, _nameModel);
                    _nextControllerStage3 = new NextControllerStage3(_mainView, _nameModel, _profilePlayers);
                    break;
                case GameStatePlug.Stage4:
                    break;
            }
        }
        
        protected override void OnDispose()
        {
            DisposeControllers();
        }

        private void DisposeControllers()
        {
            _formsController?.Dispose();
            _colorController?.Dispose();
            _nextControllerStage1?.Dispose();
            _startStage2Controller?.Dispose();
            _nextControllerStage2?.Dispose();
            _startStage3Controller?.Dispose();
            _inputFieldController?.Dispose();
            _nextControllerStage3?.Dispose();
        }
    }

}
using System;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Object = UnityEngine.Object;

namespace Controllers
{
    public class StartStage3Controller : BaseController
    {
        private const string Name = "Название команды";
        private readonly List<FormsView> _forms;
        private readonly List<FormsView> _logos;
        private readonly MainView _mainView;
        private readonly FormsColorModel _formsColorModel;
        private readonly FormsColorModel _logosColorModel;
        private readonly NameModel _nameModel;

        private FormsView _form;
        private FormsView _logo;

        public StartStage3Controller(List<FormsView> forms, List<FormsView> logos, MainView mainView,
            FormsColorModel formsColorModel, FormsColorModel logosColorModel, NameModel nameModel)
        {
            _forms = forms;
            _logos = logos;
            _mainView = mainView;
            _formsColorModel = formsColorModel;
            _logosColorModel = logosColorModel;
            _nameModel = nameModel;
            ToggleUI();
            AddImage();
            AddText();
        }

        private void AddText()
        {
            _mainView.Name.text = Name;
            _mainView.TeamName.text = _nameModel.Name;
        }

        private void AddImage()
        {
            _form = Object.Instantiate(_forms[_formsColorModel.Id], _mainView.FormConteiner);
            _form.Type0layer0.color = _formsColorModel._type0layer0;
            _form.Type0layer1.color = _formsColorModel._type0layer1;
            _form.Type0layer2.color = _formsColorModel._type0layer2;
            
            _logo = Object.Instantiate(_logos[_logosColorModel.Id], _mainView.LogoConteiner);
            _logo.Type0layer0.color = _logosColorModel._type0layer0;
            _logo.Type0layer1.color = _logosColorModel._type0layer1;
            _logo.Type0layer2.color = _logosColorModel._type0layer2;
            
            
        }

        private void ToggleUI()
        {
            foreach (var stage1Stage2 in _mainView.Stage1Stage2)
            {
                stage1Stage2.SetActive(false);
            }

            foreach (var stage3 in _mainView.Stage3)
            {
                stage3.SetActive(true);
            }
        }
    }
}
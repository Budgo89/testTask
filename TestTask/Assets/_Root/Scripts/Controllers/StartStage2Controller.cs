using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Object = UnityEngine.Object;

namespace Controllers
{
    public class StartStage2Controller : BaseController
    {
        private const string Name = "Выбери лого";
        
        private readonly MainView _mainView;
        private readonly List<FormsView> _forms;
        private readonly List<FormsView> _logosViews;
        private readonly FormsColorModel _formsColorModel;
        private readonly FormsColorModel _logosColorModel;

        private FormsView _form;

        public StartStage2Controller(MainView mainView, List<FormsView> forms, List<FormsView> logosViews, FormsColorModel formsColorModel, FormsColorModel logosColorModel)
        {
            _mainView = mainView;
            _forms = forms;
            _logosViews = logosViews;
            _formsColorModel = formsColorModel;
            _logosColorModel = logosColorModel;
            AddFodms();
            StartLogo();
            AddText();
        }

        private void AddText()
        {
            _mainView.Name.text = Name;
        }

        private void StartLogo()
        {
            var logo = _logosViews.Find(x => x.ID == _logosColorModel.Id);
            logo.gameObject.SetActive(true);
            logo.Animators.SetBool("IsLogoStart", true);
        }

        private void AddFodms()
        {
            _form = Object.Instantiate(_forms[_formsColorModel.Id], _mainView.ConteinerFormStage1);
            _form.Type0layer0.color = _formsColorModel._type0layer0;
            _form.Type0layer1.color = _formsColorModel._type0layer1;
            _form.Type0layer2.color = _formsColorModel._type0layer2;
        }
        protected override void OnDispose()
        {
            _form.gameObject.SetActive(false);
        }
        
    }
}
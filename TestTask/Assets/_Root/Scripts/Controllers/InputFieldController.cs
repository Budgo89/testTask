using DefaultNamespace;
using DefaultNamespace.Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class InputFieldController : BaseController
    {
        //private Color ColorError = new Color(182f,35f,23f, 1f);
        private Color ColorError = new Color(0.7137255f, 0.1372549f, 0.09019608f);
        private Color ColorNornal = Color.white;
        
        private readonly MainView _mainView;
        private readonly NameModel _nameModel;
        private TMP_InputField _inputField;
        

        public InputFieldController(MainView mainView, NameModel nameModel)
        {
            _mainView = mainView;
            _nameModel = nameModel;
            _inputField = _mainView.InputFields;
            _inputField.onValueChanged.AddListener(OnValueInputFieldChanged);
        }

        private void OnValueInputFieldChanged(string arg0)
        {
            if (arg0.Length > 10)
            {
                _mainView.TeamName.color = ColorError;
                _mainView.NextButton.enabled = false;
                _mainView.NextButton.interactable = false;
            }
            else
            {
                _mainView.TeamName.color = ColorNornal;
                _mainView.NextButton.enabled = true;
                _mainView.NextButton.interactable = true;
            }
        }
    }
}
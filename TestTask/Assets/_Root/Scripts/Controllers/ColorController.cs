using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Profile;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class ColorController : BaseController
    {
        private readonly MainView _mainView;
        private readonly List<FormsView> _formsViews;
        private readonly FormsColorModel _formsColorModel;
        
        private Button _randomColor;
        private Button _type0layer1Button;
        private Button _type0layer2Button;
        private Button _type0layer3Button;
        private List<ButtonColorView> _buttonColorViews;

        private Image _type0layerImage;
        private Image _type0layerFormImage;

        private List<Button> _buttons;

        private System.Random _random;

        private Type0layerEnum _type0LayerEnum;

        public ColorController(MainView mainView, List<FormsView> formsViews, FormsColorModel formsColorModel)
        {
            _mainView = mainView;
            _formsViews = formsViews;
            _formsColorModel = formsColorModel;
            AddButton();
            AddColorButton();
            SubscribeButton();
            _random = new System.Random();
            Type0layer1();
        }

        private void AddColorButton()
        {
            _mainView.Type0layer1.Images.color = _formsColorModel._type0layer0;
            _mainView.Type0layer2.Images.color = _formsColorModel._type0layer1;
            _mainView.Type0layer3.Images.color = _formsColorModel._type0layer2;
        }


        private void SubscribeButton()
        {
            _type0layer1Button.onClick.AddListener(Type0layer1);
            _type0layer2Button.onClick.AddListener(Type0layer2);
            _type0layer3Button.onClick.AddListener(Type0layer3);
            
            _buttonColorViews = _mainView.ButtonColorViews;
            _buttons = new List<Button>();
            foreach (var buttonColorView in _buttonColorViews)
            {
                var button = buttonColorView.Buttons;
                button.onClick.AddListener(() => AddType0layerColor(buttonColorView.Colors));
                _buttons.Add(button);
            }
            
            _randomColor.onClick.AddListener(OnRandimCollorClick);

        }

        private void OnRandimCollorClick()
        {
            var colorRandom = _buttonColorViews[_random.Next(0, _buttonColorViews.Count - 1)].Colors;
            AddType0layerColor(colorRandom);
        }

        private void Type0layer1()
        {
            _type0layerImage = _mainView.Type0layer1.Images;
            _type0layerFormImage = _formsViews.Find(x=> x.ID == _formsColorModel.Id).Type0layer0;
            _type0LayerEnum = Type0layerEnum.one;
        }

        private void Type0layer2()
        {
            _type0layerImage = _mainView.Type0layer2.Images;
            _type0layerFormImage = _formsViews.Find(x=> x.ID == _formsColorModel.Id).Type0layer1;
            _type0LayerEnum = Type0layerEnum.two;
        }

        private void Type0layer3()
        {
            _type0layerImage = _mainView.Type0layer3.Images;
            _type0layerFormImage = _formsViews.Find(x=> x.ID == _formsColorModel.Id).Type0layer2;
            _type0LayerEnum = Type0layerEnum.three;
        }

        private void AddType0layerColor(Color color)
        {
            if (!IsColor(color))
                return;
            _type0layerImage.color = color;
            _type0layerFormImage.color = color;
            SetColor();
        }

        private void SetColor()
        {
            switch (_type0LayerEnum)
            {
                case Type0layerEnum.one:
                    _formsColorModel._type0layer0 = _type0layerImage.color;
                    break;
                case Type0layerEnum.two:
                    _formsColorModel._type0layer1 = _type0layerImage.color;
                    break;
                case Type0layerEnum.three:
                    _formsColorModel._type0layer2 = _type0layerImage.color;
                    break;
            }
        }

        private bool IsColor(Color color)
        {
            if(_formsColorModel._type0layer0 == color)
                return false;
            if(_formsColorModel._type0layer1 == color)
                return false;
            if(_formsColorModel._type0layer2 == color)
                return false;
            return true;
        }
        
        private void AddButton()
        {
            _randomColor = _mainView.randimCollor;
            _type0layer1Button = _mainView.Type0layer1.Buttons;
            _type0layer2Button = _mainView.Type0layer2.Buttons;
            _type0layer3Button = _mainView.Type0layer3.Buttons;
        }
        
        protected override void OnDispose()
        {
            UnsubscribeButton();
        }

        private void UnsubscribeButton()
        {
            _type0layer1Button.onClick.RemoveAllListeners();
            _type0layer2Button.onClick.RemoveAllListeners();
            _type0layer3Button.onClick.RemoveAllListeners();

            foreach (var buttonColorView in _buttonColorViews)
            {
                buttonColorView.Buttons.onClick.RemoveAllListeners();
            }
        }
    }
}
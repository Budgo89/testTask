using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _teamName;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _conteinerFormStage2;
        [SerializeField] private Transform _formConteiner;
        [SerializeField] private Transform _logoConteiner;
        [SerializeField] private Button _randimCollor;
        [SerializeField] private Button _forwardButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private ButtonImageView _type0layer1;
        [SerializeField] private ButtonImageView _type0layer2;
        [SerializeField] private ButtonImageView _type0layer3;
        [SerializeField] private List<ButtonColorView> _buttonColorViews;

        [FormerlySerializedAs("_Stage1Stage2")]
        [Header("Stage1, Stage2")] 
        [SerializeField] private List<GameObject> _stage1Stage2; 
        [FormerlySerializedAs("_Stage3")]
        [Header("Stage3")] 
        [SerializeField] private List<GameObject> _stage3;

        [SerializeField] private TMP_InputField _inputField;

        
        
        public TMP_Text Name => _name;
        public TMP_Text TeamName => _teamName;
        public Transform Container => _container;
        public Transform ConteinerFormStage1 => _conteinerFormStage2;
        public Transform FormConteiner => _formConteiner;
        public Transform LogoConteiner => _logoConteiner;
        public Button randimCollor => _randimCollor;
        public Button ForwardButton => _forwardButton;
        public Button BackButton => _backButton;
        public Button NextButton => _nextButton;
        public ButtonImageView Type0layer1 => _type0layer1;
        public ButtonImageView Type0layer2 => _type0layer2;
        public ButtonImageView Type0layer3 => _type0layer3;
        public List<ButtonColorView> ButtonColorViews => _buttonColorViews;
        public List<GameObject> Stage1Stage2 => _stage1Stage2;
        public List<GameObject> Stage3 => _stage3;

        public TMP_InputField InputFields => _inputField;

    }
}
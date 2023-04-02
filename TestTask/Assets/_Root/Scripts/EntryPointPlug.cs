using System.Collections.Generic;
using DControllers;
using DefaultNamespace.Models;
using UnityEngine;
using Profile;
using Tool;

namespace DefaultNamespace
{
    public class EntryPointPlug : MonoBehaviour
    {
        [SerializeField] private List<FormsView> _forms;
        [SerializeField] private List<FormsView> _logos;
        [SerializeField] private MainView _mainView;

        private MainControllerPlug _mainControllerPlug;
        private FormsColorModel _formsColorModel;
        private FormsColorModel _logosColorModel;
        private NameModel _nameModel;


        private void Start()
        {
            var profilePlayer = new ProfilePlayersPlug(GameStatePlug.Stage1);
            _formsColorModel = GetFormsColorModel();
            _logosColorModel = GetLogosColorModel();
            _nameModel = GedNameModel();
            _mainControllerPlug = new MainControllerPlug(_mainView, _forms, _formsColorModel,_logos, _logosColorModel, profilePlayer, _nameModel);
        }

        private NameModel GedNameModel()
        {
            if (PlayerPrefs.HasKey(ConstSave.Name))
            {
                return JsonUtility.FromJson<NameModel>(PlayerPrefs.GetString(ConstSave.Name));
            }

            return new NameModel();
        }

        private FormsColorModel GetLogosColorModel()
        {
            if (PlayerPrefs.HasKey(ConstSave.Logo))
            {
                return JsonUtility.FromJson<FormsColorModel>(PlayerPrefs.GetString(ConstSave.Logo));
            }

            return new FormsColorModel();
        }

        private FormsColorModel GetFormsColorModel()
        {

            if (PlayerPrefs.HasKey(ConstSave.Form))
            {
               return JsonUtility.FromJson<FormsColorModel>(PlayerPrefs.GetString(ConstSave.Form));
            }

            return new FormsColorModel();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LackInternetView : MonoBehaviour
    {
        [SerializeField] private Button _buttonOk;

        public Button ButtonOk => _buttonOk;
    }
}
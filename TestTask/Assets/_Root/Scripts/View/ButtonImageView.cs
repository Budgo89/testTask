using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonImageView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public Button Buttons => _button;
        public Image Images => _image;
    }
}
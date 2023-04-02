using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonColorView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Color _color;

        public Button Buttons => _button;
        public Color Colors => _color;
    }
}
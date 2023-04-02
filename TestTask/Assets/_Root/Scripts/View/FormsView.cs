using UnityEngine;
using UnityEngine.UI;

public class FormsView : MonoBehaviour
{
    [SerializeField] private Image _type0layer0;
    [SerializeField] private Image _type0layer1;
    [SerializeField] private Image _type0layer2;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _id;


    public Image Type0layer0 => _type0layer0;
    public Image Type0layer1 => _type0layer1;
    public Image Type0layer2 => _type0layer2;
    public Animator Animators => _animator;
    public int ID => _id;

}

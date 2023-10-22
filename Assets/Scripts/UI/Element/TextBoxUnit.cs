
using TMPro;
using UnityEngine;

namespace UI.Element
{
    public class TextBoxUnit : MonoBehaviour
    {
        [SerializeField] private TMP_Text _power;
        
        [Space]
        [SerializeField] private Animator _animator;
        
        private bool _isOpen;
        
        public void Open()
        {
            if(_isOpen) return;
            
            _animator.SetTrigger("Open");
            
            _isOpen = true;
        }

        public void Close()
        {
            if(!_isOpen) return;
            
            _isOpen = false;
            _animator.SetTrigger("Close");
        }
        
        public void SetPower(int power)
        {
            _power.text = "Power \n" + power;
        }
    }
}
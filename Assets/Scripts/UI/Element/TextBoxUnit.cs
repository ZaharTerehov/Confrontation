
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
        
        public void OnOpen()
        {
            if(_isOpen) return;
            
            _animator.SetTrigger("Open");
            
            _isOpen = true;
        }

        public void OnClose()
        {
            if(!_isOpen) return;
            
            _isOpen = false;
            _animator.SetTrigger("Close");
        }
        
        public void SetPower(float power)
        {
            _power.text = power.ToString();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace UI.Element
{
    public class ButtonsPanel : MonoBehaviour
    {
        [SerializeField] private Button _sendUnits;
        
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
    }
}
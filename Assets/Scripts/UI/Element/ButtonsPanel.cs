
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Element
{
    public class ButtonsPanel : MonoBehaviour
    {
        [SerializeField] private Button _sendUnits;
        [SerializeField] private Button _building;
        
        [Space]
        [SerializeField] private Animator _animator;
        
        private bool _isOpen;

        public event Action SendUnits;
        public event Action Building;

        private void Start()
        {
            _sendUnits.onClick.AddListener(ClickButtonSendUnits);
            _building.onClick.AddListener(ClickButtonBuilding);
        }

        private void ClickButtonSendUnits()
        {
            SendUnits?.Invoke();
        }

        private void ClickButtonBuilding()
        {
            OnClose();
            Building?.Invoke();
        }
        
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
    }
}
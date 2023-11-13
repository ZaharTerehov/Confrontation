
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Element
{
    public class TextBoxBuild : MonoBehaviour
    {
        [SerializeField] private Button _settlementButton;
        
        [SerializeField] private Button _mineButton;
        [SerializeField] private Button _barracksButton;
        [SerializeField] private Button _stableButton;
        
        [Space]
        [SerializeField] private Animator _animator;

        public event Action ClickSettlementButton;
        
        private bool _isOpen;

        private void Start()
        {
            _settlementButton.onClick.AddListener(OnClickSettlementButton);
            
            _mineButton.onClick.AddListener(Close);
            _barracksButton.onClick.AddListener(Close);
            _stableButton.onClick.AddListener(Close);
        }

        public void OnOpen()
        {
            if(_isOpen) return;
            _animator.SetTrigger("Open");
            _isOpen = true;
        }

        private void Close()
        {
            if(!_isOpen) return;
            _isOpen = false;
            
            _animator.SetTrigger("Close");
        }

        private void OnClickSettlementButton()
        {
            ClickSettlementButton?.Invoke();
        }
    }
}
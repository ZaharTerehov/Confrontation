
using System;
using TMPro;
using UnityEngine;

namespace UI.Element
{
    public class TextBoxBuilding : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _unitCount;
        [SerializeField] private TMP_Text _goldCount;
        [SerializeField] private TMP_Text _unitPS;
        [SerializeField] private TMP_Text _goldPS;
        
        [Space]
        [SerializeField] private Animator _animator;

        private static TextBoxBuilding _instance;

        private bool _isOpen;

        private void Start()
        {
            _instance = this;
        }

        public static void SetInfo(int lvl, int unitCount, int goldCount, int unitPS, int goldPS)
        {
            _instance._lvl.text = "lvl - " + lvl;
            _instance._unitCount.text = "Unit \n" + unitCount.ToString("0.0");
            _instance._goldCount.text = "Gold \n" + goldCount;
            _instance._unitPS.text = "UnitPS \n" + unitPS;
            _instance._goldPS.text = "GoldPS \n" + goldPS;
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
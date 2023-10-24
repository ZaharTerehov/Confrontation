
using TMPro;
using UnityEngine;

namespace UI.Element
{
    public class TextBoxCapital : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TMP_Text _unitCount;
        [SerializeField] private TMP_Text _goldCount;
        [SerializeField] private TMP_Text _unitPS;
        [SerializeField] private TMP_Text _goldPS;
        
        [Space]
        [SerializeField] private Animator _animator;

        private bool _isOpen;

        private void SetLevel(int level)
        {
            _lvl.text = _lvl.text + level.ToString();
        }
        
        public void OnSetUnitCount(float unitCount)
        {
            _unitCount.text = "Gold \n" + unitCount.ToString("0.0");
        }
        
        public void OnSetGoldCount(int goldCount)
        {
            _goldCount.text = "Unit \n" + goldCount;
        }
        
        private void SetUnitPS(float unitPS)
        {
            _unitPS.text = _unitPS.text + unitPS.ToString();
        }
        
        private void SetGoldPS(float goldPS)
        {
            _goldPS.text = _goldPS.text + goldPS.ToString();
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
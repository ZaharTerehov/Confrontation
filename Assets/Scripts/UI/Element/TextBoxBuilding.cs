
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

        private bool _isOpen;

        public void SetInfo(int lvl, int unitCount, int goldCount, int unitPS, int goldPS)
        {
            _lvl.text += lvl.ToString();
            _unitCount.text = "Unit \n" + unitCount.ToString("0.0");
            _goldCount.text = "Gold \n" + goldCount;
            _unitPS.text += unitPS.ToString();
            _goldPS.text += goldPS.ToString();
        }

        // private void SetLevel(int level = 0)
        // {
        //     _lvl.text = _lvl.text + level.ToString();
        // }
        //
        // public void OnSetUnitCount(float unitCount)
        // {
        //     _unitCount.text = "Unit \n" + unitCount.ToString("0.0");
        // }
        //
        // public void OnSetGoldCount(int goldCount)
        // {
        //     _goldCount.text = "Gold \n" + goldCount;
        // }
        //
        // private void SetUnitPS(float unitPS)
        // {
        //     _unitPS.text = _unitPS.text + unitPS.ToString();
        // }
        //
        // private void SetGoldPS(float goldPS)
        // {
        //     _goldPS.text = _goldPS.text + goldPS.ToString();
        // }

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
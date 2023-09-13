using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Exit : Window
    {
        [SerializeField] private Button _back;
        [SerializeField] private Button _exit;
        
        private void Start()
        {
            _back.onClick.AddListener(ClickButtonBack);
            _exit.onClick.AddListener(ClickButtonExit);
        }
        
        private void ClickButtonExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        
        private void ClickButtonBack()
        {
            UIController.Open<Main>();
        }
    }
}
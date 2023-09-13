
using System.Collections.Generic;
using UI.Interfaces;
using UI.Windows;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UI.Services;
using Zenject;

namespace UI.Controllers
{
    public class UIController : MonoBehaviour
    {
        private static UIController _instance;

        [Inject] private IUIWindowsManagerService _uiWindowsManagerService;

        [Header("Windows")]
        [SerializeField] private Main _mainWindow;
        [SerializeField] private Settings _settingsWindow;
        [SerializeField] private CampaignMap _campaignMapWindow;
        [SerializeField] private Exit _exitWindow;

        [Space]
        [SerializeField] private List<Window> _windows = new List<Window>();
        
        private Window _currentWindow;
        private Window _previousWindow;

        public static Main GameWindow => _instance._mainWindow;
        public static Settings MainWindow => _instance._settingsWindow;
        public static CampaignMap LevelSelectionWindow => _instance._campaignMapWindow;
        public static Exit EndGameWindow => _instance._exitWindow;
        
        public static Window CurrentWindow => _instance._currentWindow;
        public static Window PreviousWindow => _instance._previousWindow;
		
        private Dictionary<Type, Window> _windowsDictionary = new Dictionary<Type, Window>();
        
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
            
            FillDictionary();
        }
        
        private void Start()
        {
            Open<Main>();
        }

        private void FillDictionary()
        {
            _instance._uiWindowsManagerService.FillDictionary(_windowsDictionary, _windows);
        }

        public static async UniTask Open<T>()
        {
            _instance._previousWindow = _instance._uiWindowsManagerService.CloseCurrent(_instance._currentWindow);
            _instance._currentWindow = _instance._uiWindowsManagerService.Open<T>(_instance._windowsDictionary);
        }
    }
}
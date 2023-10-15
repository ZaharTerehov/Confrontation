
using System.Collections.Generic;
using UI.Interfaces;
using UI.Windows;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using Gameplay.Interfaces.ConstructionElements;
using UI.Element;
using UI.Services;
using Zenject;

namespace UI.Controllers
{
    public class UIController : MonoBehaviour
    {
        [Header("Windows")]
        [SerializeField] private Main _mainWindow;
        [SerializeField] private Hud _hudWindow;
        [SerializeField] private GameObject _map;
        [SerializeField] private Settings _settingsWindow;
        [SerializeField] private CampaignMap _campaignMapWindow;
        [SerializeField] private Store _storeWindow;
        [SerializeField] private Academy _academyWindow;
        [SerializeField] private Exit _exitWindow;

        [Space]
        [SerializeField] private TextBoxCapital _textBoxCapital;
        
        [Space]
        [Header("LoadWindow")]
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _loadWindow;

        [Space]
        [SerializeField] private List<Window> _windows = new List<Window>();
        
        private Window _currentWindow;
        private Window _previousWindow;

        public static Main MainWindow => _instance._mainWindow;
        public static Hud HudWindow => _instance._hudWindow;
        public static GameObject MapWindow => _instance._map;
        public static Settings SettingsWindow => _instance._settingsWindow;
        public static CampaignMap CampaignMap => _instance._campaignMapWindow;
        public static Store StoreWindow => _instance._storeWindow;
        public static Academy AcademyWindow => _instance._academyWindow;
        public static Exit EndGameWindow => _instance._exitWindow;
        
        public static Window CurrentWindow => _instance._currentWindow;
        public static Window PreviousWindow => _instance._previousWindow;
		
        private Dictionary<Type, Window> _windowsDictionary = new Dictionary<Type, Window>();
        
        private static UIController _instance;

        [Inject] private IUIService _uiWindowsManagerService;
        [Inject] private ICapitalService _capitalService;
        [Inject] private ILevelService _levelService;
        [Inject] private IBoardService _builderService;

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
            PlayAnimationClip();

            _capitalService.AddGold += _hudWindow.SetGold;
            _capitalService.AddGold += _textBoxCapital.SetGoldCount;
            
            _capitalService.AddUnits += _textBoxCapital.SetUnitCount;
            
            _levelService.LevelLoaded += ResourceController.LoadLevel;
            _hudWindow.ExitFromPlaying += ResourceController.ExitLevel;
            _hudWindow.ExitFromPlaying += BuilderController.ClearAllCapital;

            _builderService.ClickOnCapital += _textBoxCapital.Open;
            _builderService.ClickNotOnCapital += _textBoxCapital.Close;
        }
        
        private async void PlayAnimationClip()
        {
            _loadWindow.SetActive(true);
            _animator.SetTrigger("Play");

            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                await UniTask.Yield();
            }

            _loadWindow.SetActive(false);
            Open<Main>();
        }

        private void FillDictionary()
        {
            _instance._uiWindowsManagerService.FillDictionary(_windowsDictionary, _windows);
        }

        public static void Open<T>()
        {
            _instance._previousWindow = _instance._uiWindowsManagerService.CloseCurrent(_instance._currentWindow);
            _instance._currentWindow = _instance._uiWindowsManagerService.Open<T>(_instance._windowsDictionary);
        }
    }
}
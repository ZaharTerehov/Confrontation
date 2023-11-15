
using System.Collections.Generic;
using UI.Interfaces;
using UI.Windows;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using Gameplay.Controllers;
using Gameplay.Controllers.ConstructionElements;
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
        [SerializeField] private TextBoxBuilding textBoxBuilding;
        [SerializeField] private TextBoxUnit _textBoxUnit;
        [SerializeField] private ButtonsPanel _buttonsPanel;
        [SerializeField] private TextBoxBuild _buildingPanel;
        
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
        [Inject] private ILevelService _levelService;
        [Inject] private IBoardService _boardService;
        [Inject] private IUnitService _unitService;
        [Inject] private ISettlementService _settlementService;
        [Inject] private ICapitalService _capitalService;

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

            _levelService.LevelLoaded += ResourceController.OnLoadLevel;
            _hudWindow.ExitFromPlaying += ResourceController.OnExitLevel;
            
            _hudWindow.ExitFromPlaying += BuilderController.OnClearAllCapital;
            // _buildingPanel.ClickSettlementButton += BuilderController.BuildSettlement;
            
            _boardService.ClickOnBuilding += textBoxBuilding.OnOpen;
            _boardService.ClickNotOnBuilding += textBoxBuilding.OnClose;
            
            _unitService.UnitSelected += _textBoxUnit.OnOpen;
            _unitService.UnitNotSelected += _textBoxUnit.OnClose;
            _unitService.CharacteristicsChanged += _textBoxUnit.SetPower;
            
            _boardService.ClickOnBuilding += _buttonsPanel.OnOpen;
            _boardService.ClickNotOnBuilding += _buttonsPanel.OnClose;

            _buttonsPanel.SendUnits += CapitalController.OnSendUnit;
            _buttonsPanel.Building += _buildingPanel.OnOpen;
            
            // _settlementService.ClickingSettlement += textBoxBuilding.SetInfo;
            // _capitalService.ClickingCapital += textBoxBuilding.SetInfo;
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
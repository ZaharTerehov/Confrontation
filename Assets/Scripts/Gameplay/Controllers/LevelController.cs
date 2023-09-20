
using System;
using System.Collections.Generic;
using Gameplay.Interfaces;
using UI.Controllers;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<LevelSettingData> _levelData = new List<LevelSettingData>();
        
        [SerializeField] private MapGeneratorController _mapGeneratorController;

        [Inject] private ILevelService _levelService;

        public event Action<int> InitLevels;
        public event Action<int> OpenLevel;

        private void Start()
        {
            UIController.CampaignMap.LoadSelectedLevel += OnLoadLevel;
            
            InitLevels += UIController.CampaignMap.OnInitBlockLevels;
            OpenLevel += UIController.CampaignMap.OnOpenLevel;
            
            InitLevels?.Invoke(_levelService.PassedLevels);
        }

        private void OnLoadLevel(int selectedLevel)
        {
            _levelService.LoadLevel(selectedLevel, _levelData,
                _mapGeneratorController);
        }
    }
}

using System;
using System.Collections.Generic;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using Gameplay.SO;
using UI.Controllers;
using UI.Windows;
using UnityEngine;

namespace Gameplay.Services
{
    public class LevelService : ILevelService
    {
        private int _currentLevel;
        private LevelSettingData _currentLevelSettingData;

        public event Action LevelLoaded;
        
        public int PassedLevels
        {
            get => PlayerPrefs.GetInt("PassedLevels");
            set => PlayerPrefs.SetInt("PassedLevels", value);
        }
        
        public void LoadLevel(int selectedLevel, List<LevelSettingData> levelData, 
            MapGeneratorController mapGeneratorController, GameObject map)
        {
            if (CheckLevelSelection(selectedLevel) == false)
            {
                return;
            }

            if (!UIController.HudWindow.gameObject.activeSelf)
            {
                UIController.Open<Hud>();
                map.SetActive(true);
            }

            _currentLevel = selectedLevel;
            _currentLevelSettingData = levelData[selectedLevel];

            mapGeneratorController.GenerateLevel(_currentLevelSettingData);
            
            LevelLoaded?.Invoke();
        }

        public bool CheckLevelSelection(int selectedLevel)
        {
            return selectedLevel <= PassedLevels;
        }
    }
}
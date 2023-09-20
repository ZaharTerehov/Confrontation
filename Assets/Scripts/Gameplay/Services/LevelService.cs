
using System.Collections.Generic;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using UI.Controllers;
using UI.Windows;
using UnityEngine;

namespace Gameplay.Services
{
    public class LevelService : ILevelService
    {
        private int _currentLevel;
        private LevelSettingData _currentLevelSettingData;
        
        public int PassedLevels
        {
            get => PlayerPrefs.GetInt("PassedLevels");
            set => PlayerPrefs.SetInt("PassedLevels", value);
        }
        
        public void LoadLevel(int selectedLevel, List<LevelSettingData> levelData, 
            MapGeneratorController mapGeneratorController)
        {
            if (CheckLevelSelection(selectedLevel) == false)
            {
                return;
            }
            
            if(!UIController.GameWindow.gameObject.activeSelf)
                UIController.Open<Game>();	
			
            _currentLevel = selectedLevel;
            _currentLevelSettingData = levelData[selectedLevel];

            mapGeneratorController.InitLevel(_currentLevelSettingData);
        }

        public bool CheckLevelSelection(int selectedLevel)
        {
            return selectedLevel <= PassedLevels;
        }
    }
}
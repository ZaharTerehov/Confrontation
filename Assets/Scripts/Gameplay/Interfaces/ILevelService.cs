﻿
using System.Collections.Generic;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface ILevelService
    {
        public int PassedLevels
        {
            get => PlayerPrefs.GetInt("PassedLevels");
            set => PlayerPrefs.SetInt("PassedLevels", value);
        }
        
        public void LoadLevel(int selectedLevel, List<LevelSettingData> levelData, 
            MapGeneratorController _mapGeneratorController);
        
        public bool CheckLevelSelection(int selectedLevel);
    }
}
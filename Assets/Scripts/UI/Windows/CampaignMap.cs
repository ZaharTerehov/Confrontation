
using System;
using System.Collections.Generic;
using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class CampaignMap : Window
    {
        [SerializeField] private Button _back;
        
        [SerializeField] private List<Button> _levels = new List<Button>();
        
        public event Action<int> LoadSelectedLevel;
        
        private void Start()
        {
            _back.onClick.AddListener(ClickButtonBack);
            
            foreach (var level in _levels)
            {
                level.onClick.AddListener(() => {  ClickButtonSelectLevel(level);});	
            }
        }
        
        private void ClickButtonBack()
        {
            UIController.Open<Main>();
        }
        
        private void ClickButtonSelectLevel(Button selectedLevel)
        {
            var numberSelectedLevel = _levels.IndexOf(selectedLevel);
			
            LoadSelectedLevel?.Invoke(numberSelectedLevel);
        }
        
        public void OnInitBlockLevels(int passedLevels)
        {
            for (var i = _levels.Count - 1; i > passedLevels; i--)
            {
                var number = _levels[i].gameObject.transform.GetChild(0);
                var image = _levels[i].gameObject.transform.GetChild(1);
                
                image.gameObject.SetActive(true);
                number.gameObject.SetActive(false);
            }
        }

        public void OnOpenLevel(int numberLevel)
        {
            if (numberLevel >= _levels.Count) 
                return;
			
            var image = _levels[numberLevel].gameObject.transform.GetChild(1);
            image.gameObject.SetActive(false);
        }
    }
}
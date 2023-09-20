﻿
using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Game : Window
    {
        [SerializeField] private Button _back;
        
        private void Start()
        {
            _back.onClick.AddListener(ClickButtonBack);
        }
        
        private void ClickButtonBack()
        {
            UIController.Open<CampaignMap>();
        }
    }
}
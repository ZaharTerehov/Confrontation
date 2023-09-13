
using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Main : Window
    {
        [SerializeField] private Button _play;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _store;
        [SerializeField] private Button _academy;
        [SerializeField] private Button _exit;
        
        private void Start()
        {
            _play.onClick.AddListener(ClickButtonPlay);
            _settings.onClick.AddListener(ClickButtonSettings);
            _store.onClick.AddListener(ClickButtonStore);
            _academy.onClick.AddListener(ClickButtonAcademy);
            _exit.onClick.AddListener(ClickButtonExit);
        }
        
        private void ClickButtonPlay()
        {
            UIController.Open<CampaignMap>();
        }
        
        private void ClickButtonSettings()
        {
            UIController.Open<Settings>();
        }
        
        private void ClickButtonStore()
        {
            UIController.Open<Store>();
        }
        
        private void ClickButtonAcademy()
        {
            UIController.Open<Academy>();
        }
        
        private void ClickButtonExit()
        {
            UIController.Open<Exit>();
        }
    }
}
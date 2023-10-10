
using TMPro;
using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Hud : Window
    {
        [SerializeField] private Button _back;
        [SerializeField] private TMP_Text _gold;
        
        private void Start()
        {
            _back.onClick.AddListener(ClickButtonBack);
        }
        
        private void ClickButtonBack()
        {
            UIController.Open<CampaignMap>();
            UIController.MapWindow.SetActive(false);
        }

        public void SetGold(int gold)
        {
            _gold.text = gold.ToString();
        }
    }
}
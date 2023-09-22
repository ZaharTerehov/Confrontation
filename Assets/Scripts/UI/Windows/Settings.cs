
using UI.Controllers;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Settings : Window
    {
        [SerializeField] private Button _back;
        
        [Space]
        [SerializeField] private Slider _sfx;
        [SerializeField] private Slider _music;
        
        private void Awake()
        {
            _sfx.value = AudioController.SFXVolume;
            _music.value = AudioController.MusicVolume;
        }
        
        private void Start()
        {
            _back.onClick.AddListener(ClickButtonBack);
            
            _sfx.onValueChanged.AddListener(AudioController.SetSfxVolume);
            _music.onValueChanged.AddListener(AudioController.SetMusicVolume);
        }
        
        private void ClickButtonBack()
        {
            UIController.Open<Main>();
        }
    }
}
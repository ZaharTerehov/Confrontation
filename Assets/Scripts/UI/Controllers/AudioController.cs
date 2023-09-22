
using System.Collections.Generic;
using UI.Interfaces;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace UI.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourceSFX;
        [SerializeField] private AudioSource _audioSourceMusic;
        [SerializeField] private AudioMixer _audioMixer;
        
        [Inject] private IAudioService _audioService;
		
        private readonly Dictionary<string, AudioClip> _audio = new Dictionary<string, AudioClip>();
        
        public static float SFXVolume => PlayerPrefs.GetFloat("SFX");
        public static float MusicVolume => PlayerPrefs.GetFloat("Music");

        private static AudioController _instance;

        private void Awake()
        {
            _instance = this;
            
            var audio = Resources.LoadAll<AudioClip>("Audio/");
			
            foreach (var audioClip in audio)
            {
                _audio.Add(audioClip.name, audioClip);
            }
        }

        private void Start()
        {
            _audioService.PlayMusic("The Eudaimonia Machine", _audioSourceMusic, _audio);
        }
        
        public static void PlaySound(string sound)
        {
            _instance._audioService.PlaySound(sound, _instance._audioSourceSFX, _instance._audio);
        }
        
        public static void PlayMusic(string music, bool loopable = true)
        {
            _instance._audioService.PlayMusic(music, _instance._audioSourceMusic, _instance._audio);
        }

        public static void SetSfxVolume(float volume)
        {
            _instance._audioService.SetSfxVolume(volume, _instance._audioMixer, "SFX");
        }
        
        public static void SetMusicVolume(float volume)
        {
            _instance._audioService.SetMusicVolume(volume, _instance._audioMixer, "Music");
        }
    }
}
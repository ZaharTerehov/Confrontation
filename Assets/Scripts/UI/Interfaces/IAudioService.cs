
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace UI.Interfaces
{
    public interface IAudioService
    {
        public void PlaySound(string sound, AudioSource audioSourceSFX, Dictionary<string, AudioClip> audio);

        public void PlayMusic(string music, AudioSource audioSourceMusic, 
            Dictionary<string, AudioClip> audio, bool loopable = true);

        public void SetSfxVolume(float volume, AudioMixer audioMixer);
        
        public void SetMusicVolume(float volume, AudioMixer audioMixer);
    }
}
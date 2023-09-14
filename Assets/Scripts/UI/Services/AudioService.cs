
using System.Collections.Generic;

using UI.Interfaces;
using UnityEngine;
using UnityEngine.Audio;

namespace UI.Services
{
    public class AudioService : IAudioService
    {
        public void PlaySound(string sound, AudioSource audioSourceSFX, Dictionary<string, AudioClip> audio)
        {
            audioSourceSFX.PlayOneShot(audio[sound]);
        }

        public void PlayMusic(string music, AudioSource audioSourceMusic, 
            Dictionary<string, AudioClip> audio, bool loopable = true)
        {
            audioSourceMusic.clip = audio[music];
            audioSourceMusic.loop = loopable;
            audioSourceMusic.Play();
        }

        public void SetSfxVolume(float volume, AudioMixer audioMixer)
        {
            audioMixer.SetFloat("SFX", volume);
            PlayerPrefs.SetFloat("SFX", volume);
        }

        public void SetMusicVolume(float volume, AudioMixer audioMixer)
        {
            audioMixer.SetFloat("Music", volume);
            PlayerPrefs.SetFloat("Music", volume);
        }
    }
}
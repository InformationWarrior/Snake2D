using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Snake
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip clip;
    }

    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private List<Sound> sounds = new();
        [SerializeField] private AudioSource bgSource, sfxSource;
        [SerializeField] private AudioClip[] bgAudioClips;
        [SerializeField] private GameObject[] soundBarFillers;
        
        private int currentTrackIdx = 0;
        private int clickCount;
        
        private void Start()
        {
            clickCount = 0;
            UpdateVolume(clickCount);
            
        }


        private void UpdateVolume(int volume)
        {
            float volumeLevel = (float)volume / soundBarFillers.Length;
            print(volumeLevel + " >>> volume");
            bgSource.volume = volumeLevel;
        }
        

        public void OnClickSound()
        {

        }

        private void FillSoundBar(int index)
        {
            soundBarFillers[index].SetActive(true);
        }

        private void ResetSoundBars()
        {
            for (int i = 0; i < soundBarFillers.Length; i++)
            {
                soundBarFillers[i].SetActive(false);
            }
        }

        public void PlayMusic()
        {
            bgSource.loop = true;
            bgSource.playOnAwake = true;
            bgSource.clip = bgAudioClips[currentTrackIdx];
            bgSource.Play();
            Invoke(nameof(CheckTrackUpdated), bgSource.clip.length);
        }

        private void CheckTrackUpdated()
        {
            currentTrackIdx = (currentTrackIdx + 1) % bgAudioClips.Length;
            PlayMusic();
        }

    }
}
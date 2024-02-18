using System;
using UnityEngine;

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
        [SerializeField] private AudioSource bgSource, sfxSource;
        [SerializeField] private GameObject[] soundBarFillers;
        [SerializeField] private AudioClip[] bgClips;

        private int clickCount;

        private void Start()
        {
            InitialState();
        }

        public void OnClickSound()
        {
            if (clickCount > soundBarFillers.Length - 1)
            {
                clickCount = -1;
                ResetSoundBars();
            }
            clickCount++;
            UpdateVolume(clickCount);
            FillSoundBar(clickCount - 1);
        }

        public void PlayMusic()
        {
            bgSource.loop = true;
            bgSource.playOnAwake = true;
            bgSource.clip = bgClips[0];
            bgSource.Play();
        }

        public void ChangeMusic()
        {

        }

        private void InitialState()
        {
            clickCount = 3;
            UpdateVolume(clickCount);
            FillSoundBar(clickCount - 1);
        }

        private void UpdateVolume(int volume)
        {
            float volumeLevel = (float)volume / soundBarFillers.Length;
            bgSource.volume = volumeLevel;
        }

        private void FillSoundBar(int index)
        {
            for (int i = 0; i <= index; i++)
            {
                soundBarFillers[i].SetActive(true);
            }
        }

        private void ResetSoundBars()
        {
            for (int i = 0; i < soundBarFillers.Length; i++)
            {
                soundBarFillers[i].SetActive(false);
            }
        }
    }
}
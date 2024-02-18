using System;
using UnityEngine;
using System.Collections.Generic;

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
        [SerializeField] private List<Sound> sounds;
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
            PlaySfx("ButtonClick");
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
            PlaySfx("ButtonClick");

        }

        public void PlaySfx(string name)
        {
            Sound sound = sounds.Find(x => x.Name == name);
            if (sound != null)
            {
                sfxSource.PlayOneShot(sound.clip);
            }
        }

        private void InitialState()
        {
            clickCount = 2;
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
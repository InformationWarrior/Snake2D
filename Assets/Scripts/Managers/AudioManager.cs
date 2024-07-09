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
        [SerializeField] private AudioClip[] bgClips;

        private int clickCount;
        private int soundBarLength;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (GameManager.Instance.GamePlayManager != null)
                soundBarLength = GameManager.Instance.GamePlayManager.GetLength();
            print(soundBarLength);
            InitialState();
        }

        public void OnClickSound()
        {
            PlaySfx("ButtonClick");
            if (clickCount > soundBarLength - 1)
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
            float volumeLevel = (float)volume / soundBarLength;
            bgSource.volume = volumeLevel;
        }

        private void FillSoundBar(int index)
        {
            GameManager.Instance.GamePlayManager.FillSoundBar(index);
        }

        private void ResetSoundBars()
        {
            GameManager.Instance.GamePlayManager.ResetSoundBars();
        }
    }
}
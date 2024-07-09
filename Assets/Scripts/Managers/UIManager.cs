using System;
using TMPro;
using UnityEngine;

namespace Snake
{
    public class UIManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        public void OnClickPlay()
        {
            Events_Snake.OnPressPlay.Dispatch();
        }
    }
}
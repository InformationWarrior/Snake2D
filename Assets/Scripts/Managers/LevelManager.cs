using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LevelManager : MonoBehaviour
    {
        private int currentScene = 0;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadLevel(int level)
        {
            currentScene = level;
            SceneManager.LoadScene("Level" + level);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoad;
            Events_Snake.OnPressPlay.AddListener(OnPressPlay);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
            Events_Snake.OnPressPlay.RemoveListener(OnPressPlay);
        }

        private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
        {
            GameManager.Instance.GamePlayManager = FindAnyObjectByType<GamePlayManager>();
            GameManager.Instance.MenuManager = FindObjectOfType<MenuManager>();
        }

        private void OnPressPlay()
        {
            SceneManager.LoadScene(1);
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Scene has finished loading
            OnSceneLoad();
        }

        private void OnSceneLoad()
        {
            GameManager.Instance.GamePlayManager = FindObjectOfType<GamePlayManager>();
            GameManager.Instance.MenuManager = FindObjectOfType<MenuManager>();
        }

        public void LoadLevel(string level)
        {
            currentScene = int.Parse(level);
            StartCoroutine(LoadSceneAsync("Level" + level));
        }
    }
}
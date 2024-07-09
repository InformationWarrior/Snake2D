using UnityEngine;

namespace Snake
{
    public enum SnakeSpeed { Slow, Medium, Fast }

    public class GameManager : MonoBehaviour
    {
        public SnakeSpeed CurrentSpeed { get; private set; } = SnakeSpeed.Slow;

        [SerializeField] private UIManager _uiManager;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private MenuManager _menuManager;
        [SerializeField] private GamePlayManager _gamePlayManager;

        public UIManager UIManager { get => _uiManager; }
        public LevelManager LevelManager { get => _levelManager; }
        public AudioManager AudioManager { get => _audioManager; }
        public MenuManager MenuManager { get => _menuManager; set => _menuManager = value; }
        public GamePlayManager GamePlayManager { get => _gamePlayManager; set => _gamePlayManager = value; }

        public static GameManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            AudioManager.PlayMusic();
        }

        public void SetSnakeSpeed(SnakeSpeed speed)
        {
            CurrentSpeed = speed;

            if (speed == SnakeSpeed.Slow)
            {
                Time.fixedDeltaTime = 0.15f;
            }
            else if (speed == SnakeSpeed.Medium)
            {
                Time.fixedDeltaTime = 0.08f;
            }

            else if (speed == SnakeSpeed.Fast)
            {
                Time.fixedDeltaTime = 0.04f;
            }
        }
    }
}
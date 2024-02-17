using UnityEngine;

namespace Snake
{
    public enum SnakeSpeed { Slow, Medium, Fast}

    public class GameManager : MonoBehaviour
    {
        public SnakeSpeed CurrentSpeed { get; private set; } = SnakeSpeed.Slow;

        [SerializeField] private UIManager _uiManager;
        [SerializeField] private AudioManager _audioManager;

        public UIManager UIManager { get => _uiManager; }
        public AudioManager AudioManager { get => AudioManager; }

        public static GameManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
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
using TMPro;
using UnityEngine;

namespace Snake
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private GameObject pauseBtn, resumeBtn;
        [SerializeField] private GameObject speedPanel;
        [SerializeField] private GameObject invisibleBtn;

        private bool speedPanelStatus;

        private void Awake()
        {
            speedPanelStatus = true;
        }

        private void Start()
        {
            ToggleSpeedPanel();
            ToggleInvisibleButton(false);
            TogglePauseUI(true);
        }

        public void DisplayScore(int score)
        {
            this.score.text = score.ToString();
        }

        public void PauseGame()
        {
            TogglePauseUI(false);
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            TogglePauseUI(true);
            Time.timeScale = 1f;
        }

        public void StopGame()
        {

        }

        private void TogglePauseUI(bool status)
        {
            pauseBtn.SetActive(status);
            resumeBtn.SetActive(!status);
        }

        public void ToggleSpeedPanel()
        {
            speedPanelStatus = !speedPanelStatus;
            speedPanel.SetActive(speedPanelStatus);
            ToggleInvisibleButton(speedPanelStatus);
        }

        public void CloseSpeedPanel()
        {
            speedPanelStatus = false;
            speedPanel.SetActive(false);
            ToggleInvisibleButton(false);
        }

        private void ToggleInvisibleButton(bool status)
        {
            invisibleBtn.SetActive(status);
        }

        public void SetSpeed(int speed)
        {
            GameManager.Instance.SetSnakeSpeed((SnakeSpeed)speed);
        }
    }
}
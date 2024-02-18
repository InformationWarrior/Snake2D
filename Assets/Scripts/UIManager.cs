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
            PlayButtonClick();
            TogglePauseUI(false);
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            PlayButtonClick();
            TogglePauseUI(true);
            Time.timeScale = 1f;
        }

        private void TogglePauseUI(bool status)
        {
            pauseBtn.SetActive(status);
            resumeBtn.SetActive(!status);
        }

        public void ToggleSpeedPanel()
        {
            PlayButtonClick();
            speedPanelStatus = !speedPanelStatus;
            speedPanel.SetActive(speedPanelStatus);
            ToggleInvisibleButton(speedPanelStatus);
        }

        public void CloseSpeedPanel()
        {
            PlayButtonClick();
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
            PlayButtonClick();
            GameManager.Instance.SetSnakeSpeed((SnakeSpeed)speed);
        }

        private void PlayButtonClick()
        {
            GameManager.Instance.AudioManager.PlaySfx("ButtonClick");
        }
    }
}
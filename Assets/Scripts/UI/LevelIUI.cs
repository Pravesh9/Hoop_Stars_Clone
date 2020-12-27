using UnityEngine;
using UnityEngine.UI;

namespace HoopStar
{

    public class LevelIUI : MonoBehaviour
    {
        [Header("Scoring UI")]
        public Text PlayerScore;
        public Text BotScore;

        [Header("Gameover UI")]
        public GameObject GameOverPanel;
        public Text GameOverPlayerStatusText;

        [Header("Timer UI")]
        public Text TimerText;

        public Text TapToStartText;
        bool hasGameStart;

        void OnEnable()=> GameManager.OnGameOver += GameOver;
        void OnDisable()=> GameManager.OnGameOver -= GameOver;
        void GameOver() => GameOverPanel.SetActive(true);

        void Update()
        {
            SetAllUIText();
            SetInitialInstruction();
        }

        private void SetInitialInstruction()
        {
            if (!hasGameStart)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    TapToStartText.gameObject.SetActive(false);
                    Time.timeScale = 1f;
                    hasGameStart = true;
                }
            }
        }

        private void SetAllUIText()
        {
            TimerText.text = Timer.instance.GetCurrentTime();
            PlayerScore.text = ScoreManager.instance.playerScore.ToString();
            BotScore.text = ScoreManager.instance.botScore.ToString();
            GameOverPlayerStatusText.text = GameManager.instance.playerStatus;
        }

         
    }
}
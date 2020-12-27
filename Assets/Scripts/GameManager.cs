using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HoopStar
{

    public class GameManager : MonoBehaviour
    {
        #region Public Fields

        public static GameManager instance;
        public static event Action OnGameOver = delegate { };
        public UnityEvent _OnGameOver;
        [HideInInspector]
        public string playerStatus;
        #endregion

        void Awake()=> instance = this;

        public void Retry() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        public void LoadScene(string _name) => SceneManager.LoadScene(_name);

        public void GameOver()
        {
            OnGameOver?.Invoke();
            _OnGameOver.Invoke();
            CheckWining();
        }

        public void CheckWining()
        {

            if (ScoreManager.instance.playerScore == ScoreManager.instance.botScore)
            {
                playerStatus = "Result Tie";
            }
            else if (ScoreManager.instance.playerScore > ScoreManager.instance.botScore)
            {
                //Player will win
                playerStatus = "You Won!";
            }
            else
            {//Player will Lost
                playerStatus = "You Lost!";
            }
        }
        public void CheckWiningOnGetPoint()
        {

            if (ScoreManager.instance.playerScore == ScoreManager.instance.minScoreNeedToWin)
            {
                //Player will win
                playerStatus = "You Won!"; OnGameOver?.Invoke();
                _OnGameOver.Invoke();
            }
            else if (ScoreManager.instance.botScore == ScoreManager.instance.minScoreNeedToWin)
            {
                playerStatus = "You Lost!"; OnGameOver?.Invoke();
                _OnGameOver.Invoke();
            }
        }

    }
}
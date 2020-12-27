using UnityEngine;

namespace HoopStar
{

    public class Timer : MonoBehaviour
    {
        public static Timer instance;
        [SerializeField]
        float min, Second = 60;
        [SerializeField]
        string currenttime;
        [HideInInspector]
        public bool GamePause;

        public bool timeup;



        private void Awake()=> instance = this;
        void PauseTheTime() => GamePause = true;
        void PlayTheTime() => GamePause = false;
        void Start() => Time.timeScale = 0f;
        

        void OnEnable()
        {
            GameManager.OnGameOver += PauseTheTime;

        }
        void OnDisable()
        {
            GameManager.OnGameOver -= PauseTheTime;

        }



        // Update is called once per frame
        void Update()
        {
            if (!GamePause)
            {
                TimerSet();
            }
            if (timeup)
            {
                min = -1;
                timeup = false;
            }
        }

        void TimerSet()
        {
            Second -= Time.deltaTime;
            if (Second <= 1)
            {
                min--;
                Second = 59;
            }

            if (min < 0)
            {

                GameManager.instance.GameOver();
                Debug.Log("timeup ");
                currenttime = "00 : 00";
                GamePause = true;
            }
            else
            {
                currenttime = min + " : " + Mathf.RoundToInt(Second).ToString();
            }
        }

        public string GetCurrentTime()
        {
            float totalTime = (min * 60) + Mathf.RoundToInt(Second);
            return totalTime.ToString();
            //return currenttime;
        }

        public void IncreaseTimer()
        {
            int timeincrease = 5;
            int tempsec = (int)((min * 60) + Second) + timeincrease;
            min = tempsec / 60;
            Second = tempsec % 60;
        }
    }


}
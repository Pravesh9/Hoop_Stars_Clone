using UnityEngine;


namespace HoopStar
{

    public class ScoreManager : MonoBehaviour
    {

        public static ScoreManager instance;
        [Header("SCORE NEEDED TO WIN")]
        public int minScoreNeedToWin;
        [Space(10f)]
        [Header("SCORE")]
        public int playerScore;
        public int botScore;

            
        void Awake()=> instance = this;
        

    }
}
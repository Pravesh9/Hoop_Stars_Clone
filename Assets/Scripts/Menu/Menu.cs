using UnityEngine;
using UnityEngine.SceneManagement;

namespace HoopStar
{

    public class Menu : MonoBehaviour
    {
        public static Menu instance;

        void Awake() => instance = this;

        public void PlayTheGame(string _sceneName)
        {

            SceneManager.LoadScene(_sceneName);
        }


    }
}

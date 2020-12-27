using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoopStar
{

    public class RingCollider : MonoBehaviour
    {
        #region Public Fields

        public float maxDistanceToGetPoint;
        public int totalpoint;
        public bool can_take_Point;

        #endregion


        void OnTriggerStay(Collider col)
        {
            if (col.tag == "ball")
            {
                OnCollideWithBall(col);
            }

        }

        void OnCollideWithBall(Collider col)
        {
            if (can_take_Point && Vector2.Distance(col.transform.position, transform.position) <= maxDistanceToGetPoint)
            {
                print("GetPoint");
                totalpoint++;
                can_take_Point = false;

                if (GetComponent<RingController>().AI)
                {
                    ScoreManager.instance.botScore = totalpoint;
                }
                else
                {
                    Handheld.Vibrate();
                    ScoreManager.instance.playerScore = totalpoint;

                }

                GameManager.instance.CheckWiningOnGetPoint();

            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag == "ball")
            {
                can_take_Point = true;
            }

        }
    }
}
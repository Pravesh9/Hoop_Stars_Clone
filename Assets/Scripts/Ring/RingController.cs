using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoopStar
{

    public class RingController : MonoBehaviour
    {

        #region Public Fields Edit via Inspector

        public float power;
        public Rigidbody Rb;
        public GameObject Ball;
        public bool AI;

        #endregion

        bool canControl;//Used to check ring can jump or not

        #region Monobehaviour Methods
        void OnEnable()
        {
            GameManager.OnGameOver += OffTheController;

        }
        void OnDisable()
        {
            GameManager.OnGameOver -= OffTheController;

        }
        void Start()
        {
            canControl = true;
            if (AI)
            {
                StartCoroutine(StartAIController());
            }
        }
        void Update()
        {
            if (!AI && canControl)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mousePos = Input.mousePosition;

                    Rb.velocity = Vector2.zero;
                    if (mousePos.x < Screen.width / 2) // LeftSide
                    {


                        Rb.AddForce((Vector2.up - Vector2.right) * power);
                    }
                    else//RightSide
                    {

                        Rb.AddForce((Vector2.up + Vector2.right) * power);
                    }
                }
            }

        }
        void OnDrawGizmos()
        {

            //Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y), (transform.up - transform.right));
            //Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y), (transform.up + transform.right));
        }
        #endregion

        void OffTheController()
        {
            canControl = false;
            if (AI)
            {
                StopAllCoroutines();
            }


        }

        IEnumerator StartAIController()
        {

            Transform Target = GameObject.FindGameObjectWithTag("ball").transform.parent.transform;
            while (true)
            {

                int r = UnityEngine.Random.Range(1, 3);

                if (transform.position.y <= Target.position.y)
                {
                    Rb.velocity = Vector2.zero;
                    if (r == 2)
                    {
                        Rb.AddForce((Vector2.up - Vector2.right) * power);
                    }

                    else
                    {
                        Rb.AddForce((Vector2.up + Vector2.right) * power);
                    }


                }
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 0.5f));
            }
        }

      
    }

}
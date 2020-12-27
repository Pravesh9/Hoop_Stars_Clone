
using UnityEngine;

namespace HoopStar
{

    public class CameraFollow : MonoBehaviour
    {
        #region Public Fields
        public Transform target;
        public Vector3 offset;
        public float speed;
        #endregion

        
        // Update is called once per frame
        void LateUpdate()
        {
            Vector2 temp = Vector2.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);

            temp.y = Mathf.Clamp(temp.y, -1f, -0.4f);
            transform.position = new Vector3(transform.position.x, temp.y, transform.position.z);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoopStar
{

    [RequireComponent(typeof(Text))]
    public class TextColorAnimation : MonoBehaviour
    {
        [Range(0.1f, 2f)]
        public float speed;

        #region Private Fields

        private Text currentText;
        private string completeText;
        private string initialtext;

        #endregion

        IEnumerator Start()
        {
            currentText = GetComponent<Text>();
            initialtext = currentText.text;


            while (true)
            {
                yield return new WaitForSeconds(2 - speed);


                completeText = "";
                for (int i = 0; i < initialtext.Length; i++)
                {
                    Color _color = Color.red;
                    _color.r = Random.Range(0f, 1f);
                    _color.g = Random.Range(0f, 1f);
                    _color.b = Random.Range(0f, 1f);
                    _color.a = 1;
                    completeText += "<Color=#" + ColorUtility.ToHtmlStringRGBA(_color) + ">" + initialtext[i] + "</Color>";
                }
                currentText.text = completeText;


            }
        }
    }
}
using System.Collections;
using UnityEngine;
using TMPro;

namespace Snake
{
    public class ChangeColor : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                ChangeColr();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void ChangeColr()
        {
            text.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.5f, 0.8f));
        }
    }
}
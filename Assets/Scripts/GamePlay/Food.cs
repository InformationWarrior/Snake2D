using UnityEngine;

namespace Snake
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private Collider2D foodSpawnArea;

        private void Start()
        {
            GenerateRandomPosition();
        }

        private void GenerateRandomPosition()
        {
            Bounds bounds = foodSpawnArea.bounds;

            float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            transform.position = new Vector3(x, y);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayWinSound();
                GenerateRandomPosition();
            }
        }

        private void PlayWinSound()
        {
            GameManager.Instance.AudioManager.PlaySfx("Win");
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Snake : MonoBehaviour
    {
        private Vector2 direction = Vector2.right;
        [SerializeField] private Transform bodyElement;
        List<Transform> snakeBody;
        [SerializeField] private Transform parent;

        private void Awake()
        {
            snakeBody = new List<Transform>() { this.transform };
        }
        private void Start()
        {
            Time.fixedDeltaTime = 0.1f;
            ResetSnake();
        }

        private void Update()
        {
            PlayerInput();
        }

        private void FixedUpdate()
        {
            Follow();
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Food"))
            {
                Grow();
            }

            if (collision.CompareTag("Obstacles"))
            {
                ResetSnake();
            }
        }

        private void ResetSnake()
        {
            for (int i = 1; i < snakeBody.Count; i++)
            {
                Destroy(snakeBody[i].gameObject);
            }
            snakeBody.Clear();
            snakeBody.Add(this.transform);
            transform.position = new Vector3(0, 0, 0);
            direction = Vector3.right;
            UpdateScore(0);
        }

        private void Grow()
        {
            Transform element = Instantiate(bodyElement, parent);
            element.position = snakeBody[^1].position;
            snakeBody.Add(element);
            UpdateScore(snakeBody.Count - 1);
        }

        private void PlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector2.right;
            }
        }

        private void Follow()
        {
            for (int i = snakeBody.Count - 1; i > 0; i--)
            {
                snakeBody[i].position = snakeBody[i - 1].position;
            }
        }

        private void Move()
        {
            float xPos = Mathf.Round(transform.position.x + direction.x);
            float yPos = Mathf.Round(transform.position.y + direction.y);
            transform.position = new Vector2(xPos, yPos);
        }

        private void UpdateScore(int score)
        {
            GameManager.Instance.UIManager.DisplayScore(score);
        }
    }
}
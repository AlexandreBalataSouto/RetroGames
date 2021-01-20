using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    public float speed = 10;
    private bool hasTheBallMoved = false;

    private void Update()
    {
        if (GameManager_Script.sharedInstance.gameStarted == true && hasTheBallMoved == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            hasTheBallMoved = true;
        }

        if (GameManager_Script.sharedInstance.gameStarted)
        {
            string paddleName = (GetComponent<Rigidbody2D>().velocity.x > 0 ? "PaddletLeft" : "PaddleRight");
            GameObject paddle = GameObject.Find(paddleName);
            GetComponent<SpriteRenderer>().color = paddle.GetComponent<SpriteRenderer>().color;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        speed = (speed >= 50 ? speed : (speed + (speed * 0.2f)));

        if (other.gameObject.name == "PaddleLeft")
        {
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            Vector2 direction = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (other.gameObject.name == "PaddleRight")
        {
            float y = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.y);

            Vector2 direction = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / paddleHeight;
    }
}

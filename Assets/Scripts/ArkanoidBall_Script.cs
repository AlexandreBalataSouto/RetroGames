using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBall_Script : MonoBehaviour
{
    public float speed = 5;
    public GameObject ballStartPosition;
    public int lifes = 3;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        StartCoroutine("UpgradeDifficulty");
    }

    IEnumerator UpgradeDifficulty(){
        while(true){
            yield return new WaitForSeconds(1.0f);
            speed *= 1.005f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().Play();
        if (other.gameObject.name == "Paddle")
        {
            float x = hitFactor(this.transform.position, other.transform.position, other.collider.bounds.size.x);

            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth)
    {
        return (ballPosition.x - paddlePosition.x) / paddleWidth;
    }
    public void ResetBall()
    {
        lifes--;
        speed = 5;
        if (lifes > 0)
        {
            transform.position = ballStartPosition.transform.position;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Invoke("RestartBallMovement", 2.0f);
        }
    }

    private void RestartBallMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Script : MonoBehaviour
{
    public static GameManager_Script sharedInstance = null;
    public bool gameStarted = false;
    public Text title;
    public Button buttonStart;
    GameObject ball;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    public void StartGame(){
        gameStarted = true;
        title.enabled = false;
        buttonStart.gameObject.SetActive(false);
        ball = GameObject.FindGameObjectWithTag("Ball");
    }
    
    public void GoalScored(){
        ball.transform.position = Vector2.zero;
        Ball_Script b = ball.GetComponent<Ball_Script>();
        b.speed = 10;
        Vector2 direction = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0);
        ball.GetComponent<Rigidbody2D>().velocity = direction.normalized * b.speed;
    }
}

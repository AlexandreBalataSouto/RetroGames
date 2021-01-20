using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalZone_Script : MonoBehaviour
{
    public Text scoreText;
    int score;
    public GameObject paddle;

    private void Awake() {
        score = 0;
        scoreText.text = score.ToString();
        scoreText.color = paddle.GetComponent<SpriteRenderer>().color;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        score++;
        scoreText.text = score.ToString();

        GameManager_Script.sharedInstance.GoalScored();
    }
}

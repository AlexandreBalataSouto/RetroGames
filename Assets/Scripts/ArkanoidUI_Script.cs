using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArkanoidUI_Script : MonoBehaviour
{
    public Image life01, life02, life03;
    public Text gameOverText, youWinText, timeText, highscoreText;
    private bool isGameEnded = false;
    private float gameTime = 0.0f;
    ArkanoidBall_Script ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<ArkanoidBall_Script>();
        youWinText.enabled = false;
        gameOverText.enabled = false;
        highscoreText.text = PlayerPrefs.GetFloat("highscore", 9999).ToString("N2");
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameEnded){
            return;
        }

        gameTime += Time.deltaTime;
        timeText.text = gameTime.ToString("N2");

        if(ball.lifes < 3){
            life03.enabled = false;
        }
        if(ball.lifes < 2){
            life02.enabled = false;
        }
        if(ball.lifes < 1){
            life01.enabled = false;
            gameOverText.enabled = true;
            Invoke("GoToMainMenu", 2.0f);
            isGameEnded = true;
        }

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length == 0){
            youWinText.text = "You Win \n"+gameTime.ToString("N2");
            youWinText.enabled = true;
            isGameEnded = true;

            float highscore = PlayerPrefs.GetFloat("highscore", 9999);
            if(gameTime < highscore){
                PlayerPrefs.SetFloat("highscore", gameTime);
            }
        }
    }

     private void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}

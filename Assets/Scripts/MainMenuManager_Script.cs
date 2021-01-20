using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager_Script : MonoBehaviour
{
    public void LoadPong(){
        SceneManager.LoadScene("PongScene");
    }

    public void LoadArkanoid(){
        SceneManager.LoadScene("ArkanoidScene");
    }
    public void LoadMinesweeper(){
        SceneManager.LoadScene("MinesweeperScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinesweeperUI_Script : MonoBehaviour
{
    public Text gameOverText, youWinText;
    public static bool isMineExplote = false;

    // Start is called before the first frame update
    void Start()
    {
        youWinText.enabled = false;
        gameOverText.enabled = false;
    }


     void Update() {
      if(isMineExplote){
           gameOverText.enabled = true;
       }else if(GridHelper_Script.HasTheGameEnded() && isMineExplote == false){
           youWinText.enabled = true;
       }
    }
}

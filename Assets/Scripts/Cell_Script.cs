using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cell_Script : MonoBehaviour
{
    public bool hasMine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    void Start()
    {
                   //El 15% del tablero tendra minas
        hasMine = (Random.value < 0.15);
        //loadTexture(8);

        int x = (int)this.transform.position.x;
        int y = (int)this.transform.parent.transform.position.y;
        GridHelper_Script.cells[x,y] = this;
    }

    public bool IsCoreverd(){
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Panel";
    }

    private void OnMouseUp() {
        if(hasMine){
            MinesweeperUI_Script.isMineExplote = true;
            GridHelper_Script.UncoverAllMines();
            Invoke("ReturnToMainMenu", 3.0f);
        }else{

            int x = (int)this.transform.position.x;
            int y = (int)this.transform.parent.transform.position.y;
            loadTexture(GridHelper_Script.CountAdjacentMines(x,y));
            
            GridHelper_Script.FloodFillUncover(x,y, new bool[GridHelper_Script.width, GridHelper_Script.height]);

            if(GridHelper_Script.HasTheGameEnded()){
                Invoke("ReturnToMainMenu", 3.0f);
            }
        }
    }

    //Para comprobar si se cargan las texturas
    public void loadTexture(int adjacentCount){
        if(hasMine){
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }else{
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
        }
    }

    private void ReturnToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
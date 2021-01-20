using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper_Script : MonoBehaviour
{
    public static int width = 15;
    public static int height = 15;
    public static Cell_Script[,] cells = new Cell_Script[width,height];
    
    public static void UncoverAllMines(){
        foreach(Cell_Script c in cells){
           if(c.hasMine){
               c.loadTexture(0);
           }
        }
    }

    public static bool HasMineAt(int x, int y){
        if(x >= 0 && y >= 0 && x < width && y < height){
            Cell_Script cell = cells[x,y];
            return cell.hasMine;
        }else{
            return false;
        }
    }

    public static int CountAdjacentMines(int x, int y){
        int count = 0;

        if(HasMineAt(x-1, y-1)) count++; //abajo-izquierda
        if(HasMineAt(x-1, y)) count++; //abajo-centro
        if(HasMineAt(x-1, y+1)) count++; //abajo-derecha
        if(HasMineAt(x, y-1)) count++; //medio-izquierda
        if(HasMineAt(x, y+1)) count++; //medio-derecha
        if(HasMineAt(x+1, y-1)) count++; //arriba-izquierda
        if(HasMineAt(x+1, y)) count++; //arriba-centro
        if(HasMineAt(x+1, y+1)) count++; //arriba-derecha

        return count;
    }

    public static void FloodFillUncover(int x, int y, bool [,] visited){
        
        if( x >= 0 && y >= 0 && x < width && y < height){

            if(visited[x,y]){
                return;
            }

            //Cuento el numero de minas adyacentes a mi posicion (x,y)
            int adjacentMines = CountAdjacentMines(x,y);
            
            //Muestro en la celda el numero de minas adyacentes (desde 0 a 8 maximo)
            cells[x,y].loadTexture(adjacentMines);

            //Si tengo minas adyacentes, no puedo seguir destapando
            if(adjacentMines > 0){
                return;
            }

            //Marco la actual como visitada
            visited[x,y] = true;

            //Visito todo los vecinos en C4 de la celda actual
            FloodFillUncover(x - 1, y, visited); //Izquierda
            FloodFillUncover(x + 1, y, visited); // Derecha
            FloodFillUncover(x, y - 1, visited); //Abajo
            FloodFillUncover(x, y + 1, visited); //Arriba
        }
    }

    public static bool HasTheGameEnded(){
        foreach(Cell_Script cell in cells){
            if(cell.IsCoreverd() && !cell.hasMine){
                return false;
            }
        }

        return true;
    }
}

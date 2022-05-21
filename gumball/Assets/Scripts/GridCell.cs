using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{

    private int posX;
    private int posY;

    // Saves a reference to the gameobject that gets place on the cell
    public GameObject objectInThisGridSpace = null;

    // Saves if the grid space is occupied or not
    public bool isOccupied = false;
    public bool isClick = false;

    // Set the position of this grid cell on the grid
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
    
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }
}

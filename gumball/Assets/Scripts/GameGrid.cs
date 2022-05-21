using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{


    // Start is called before the first frame update

    private int height = 9;
    private int width = 9;
    private float GridSpaceSize = 1.25f;

    [SerializeField] private GameObject gridCellPrefab;

    private GameObject[,] gameGrid;


    void Start()
    {
        //CreateGrid();
        StartCoroutine(CreateGrid());
    }

    // creates the grid when the game starts
    //private void CreateGrid()
    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[height, width];

        if (gridCellPrefab == null)
        {
            Debug.LogError("ERROR: Prefab Not Assigned!");
            yield return null;
        }

        // Make the Grid
        for (int y=0; y<height; y++)
        {
            for(int x = 0; x<width;x++)
            {
                gameGrid[x, y] = Instantiate(gridCellPrefab, new Vector3(x * GridSpaceSize, y * GridSpaceSize), Quaternion.identity);
                gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                gameGrid[x, y].transform.parent = transform;
                gameGrid[x, y].gameObject.name = "Grid Space ( X: " + x.ToString() + " , Y: " + y.ToString() + ")";

                yield return new WaitForSeconds(.025f);
            }
        }
    }

    public Vector2Int GetGridPosFromWorld(Vector3 wordPosition)
    {
        int x = Mathf.FloorToInt(transform.position.x / GridSpaceSize);
        int y = Mathf.FloorToInt(transform.position.y / GridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x, y);
    }

    // Gets the world position of a grid pos
    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * GridSpaceSize;
        float y = gridPos.y * GridSpaceSize;

        return new Vector3(x, 0, y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        if (cellMouseIsOver != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(cellMouseIsOver.isOccupied);
                if (!cellMouseIsOver.isClick)
                {
                    cellMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.red;
                    cellMouseIsOver.isClick = true;
                }
                else
                {
                    cellMouseIsOver.GetComponent<MeshRenderer>().material.color = myMaterial.color;
                    cellMouseIsOver.isClick = false;
                }
            }
        }
    }


    // Returns the grid cell if mouse is over a grid cell and returns null if is not
    private GridCell IsMouseOverAGridSpace()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGridLayer))
        {
            return hitInfo.transform.GetComponent<GridCell>(); 
        }
        else
        {
            return null;
        }
    }
}

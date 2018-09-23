using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour 
{
    //we need size of the grid by x and y 
    //we need a 2D array of nodes
    //we need a node radius and a node diameter
    //we need to know what the grids x and y value individually 
    //we need a layermask to determine if an area is unwalkable or not

    public LayerMask unwalkable;
    public Vector2 gridWorldSize;
    Node[,] grid;
    int gridSizeX;
    int gridSizeY;
    public float nodeRadius;
    float nodeDiameter;



	// Use this for initialization
	void Start () {
        //set Diameter to 2 * radius
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - (Vector3.right * gridWorldSize.x/2) - (Vector3.forward * gridWorldSize.y / 2);
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkable));
                grid[x, y] = new Node(walkable, worldPoint);
            }
        }
    }


    //we need a Node to world point method that takes in a bool walkable and vector3 position
    public void NodeToWorldPoint(bool _walkable, Vector3 _worldPos)
    {

    }

    //we need a draw method (onDrawGizmo)
    public void OnDrawGizmos()
    {

    }

}

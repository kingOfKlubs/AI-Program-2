using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node {

    //what do we need to define our Nodes?

    //we need to know if it is walkable 
    //we need to know what the position is in the world
    public bool walkable;
    public Vector3 worldPos;

    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;

    public Node parent;

    //we need a contructor for the node class
    public Node(bool _walkable, Vector3 _worldPos,int _gridX,int _gridY)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost { get { return gCost + hCost; } }
	
}

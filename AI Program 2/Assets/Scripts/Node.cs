using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node
{


    public bool walkable;
    public Vector3 worldPos;

    public int gCost;
    public int hCost;

    public int gridX;
    public int gridY;

    public Node parent;

    public float t;
    public float deltaE;

    //we need a contructor for the node class
    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost { get { return gCost + hCost; } }

    public float DeltaE { get { return 1 + Mathf.Exp(deltaE / t); } }




    //class for nodes 


}





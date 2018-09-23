using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    //what do we need to define our Nodes?

    //we need to know if it is walkable 
    //we need to know what the position is in the world
    public bool walkable;
    public Vector3 worldPos;

    //we need a contructor for the node class
    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPos = _worldPos;
    }
	
}

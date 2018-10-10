using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleNode : MonoBehaviour
{

    public List<puzzleNode> neighbours;
    public int x;
    public int y;

    public puzzleNode()
    {
        neighbours = new List<puzzleNode>();
    }

    public float DistanceTo(puzzleNode n)
    {
        return Vector2.Distance(new Vector2(x, y), new Vector2(n.x, n.y));
    }
}





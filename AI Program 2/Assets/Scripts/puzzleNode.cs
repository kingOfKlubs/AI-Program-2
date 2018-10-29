using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleNode : MonoBehaviour
{

    public List<puzzleNode> neighbours;
    public int x;
    public int y;

    public float deltaE;
    public float t;

    public puzzleNode()
    {
        neighbours = new List<puzzleNode>();
    }
    public float DeltaE { get { return 1 + Mathf.Exp(deltaE / t); } }
}





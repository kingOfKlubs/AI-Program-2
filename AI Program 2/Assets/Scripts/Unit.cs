using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Transform unit, goal;
    public float speed;
    public PathFinding pathFinding;
    public List<Node> path;
	
	// Update is called once per frame
	void Update () {

        FindPath();
     
          
	}

    void FindPath()
    {
        pathFinding.FindPath(unit.position, goal.position);
        if (path == null)
            return;
        
            unit.position = Vector3.MoveTowards(unit.position, new Vector3(path[0].worldPos.x, 1, path[0].worldPos.z), speed);

        
    }
}

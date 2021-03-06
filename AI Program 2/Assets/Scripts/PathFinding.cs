﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

    Grid grid;
    public Unit unit;
    public Transform seeker, target;
    public float speed;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void FixedUpdate()
    {
        FindPath(seeker.position, target.position);
        
    }

    public void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].DeltaE < currentNode.DeltaE || openSet[i].DeltaE == currentNode.DeltaE && openSet[i].t < currentNode.t)
                {
                    currentNode = openSet[i];
                }
            }
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                ReversePath(startNode, targetNode);
                return;
            }

            foreach(Node neighbours in grid.GetNeighbours(currentNode))
            {
                if (!neighbours.walkable || closedSet.Contains(neighbours))
                {
                    continue;
                }

                float newMovementCostToNeighbour = currentNode.deltaE + GetDistance(currentNode, neighbours);
                if (newMovementCostToNeighbour < neighbours.deltaE || !openSet.Contains(neighbours))
                {
                    neighbours.deltaE = newMovementCostToNeighbour;
                    neighbours.t = GetDistance(neighbours, targetNode);
                    neighbours.parent = currentNode;

                    if(!openSet.Contains(neighbours))
                    {
                        openSet.Add(neighbours);
                    }
                }
            }
        }
    }

    void ReversePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();

        Node currnetNode = endNode;
        while(currnetNode != startNode)
        {
            path.Add(currnetNode);
            currnetNode = currnetNode.parent;
        }
        path.Reverse();

        grid.path = path;
        unit.path = path;

    }

    float GetDistance(Node nodeA, Node nodeB)
    {
        float dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        float dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
        {
            return 14 * dstY + 10 * (dstX - dstY);
        }
        else
            return 14 * dstX + 10 * (dstY - dstX);
    }
}

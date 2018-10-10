// Course: CS4242
// Student name: Caleb Mauldin
// Student ID: 000-54-0901
// Assignment #: 1
// Due Date: 09/12/2018
// Signature: ______________
// Score: ______________
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public GameObject selectedUnit;

    public TileType[] tileTypes;

    int[,] Tiles;
    puzzleNode[,] graph;

    public int mapSizeX = 5;
    public int mapSizeY = 5;

    // Use this for initialization
    void Start()
    {
        //selectedUnit.GetComponent<Unit1>().tileX = (int)selectedUnit.transform.position.x;
        //selectedUnit.GetComponent<Unit1>().tileY = (int)selectedUnit.transform.position.y;
        //selectedUnit.GetComponent<Unit1>().map = this;


        GenerateMapData();
        GeneratePathFinding();
        GenerateMap();
    }
    //generates the type of tiles placed randomly 
    void GenerateMapData()
    {
        Tiles = new int[mapSizeX, mapSizeY];

        int x, y, i = 0;

        for (x = 0; x < mapSizeX; x++)
        {
            for (y = 0; y < mapSizeX; y++)
            {
                Tiles[x, y] = i++;
            }
        }
        //Tiles[0,0] = 0;
        //Tiles[1, 0] = 1;
        //Tiles[2, 0] = 2;
        //Tiles[0, 1] = 3;
        //Tiles[1, 1] = 4;
        //Tiles[2, 1] = 5;
        //Tiles[0, 2] = 6; 
        //Tiles[1, 2] = 7;
        //Tiles[2, 2] = 8;

    }


    //finds the cost to get to the tile
    public float CostToEnterTile(int x, int y)
    {
        TileType tt = tileTypes[Tiles[x, y]];

        if(CanEnterTile(x,y) == false)
        {
            return Mathf.Infinity;
        }

        return tt.movementCost;
    }

    //generates a node for every tile
    void GeneratePathFinding()
    {
        graph = new puzzleNode[mapSizeX, mapSizeY];
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeX; y++)
            {
                graph[x, y] = new puzzleNode();
                graph[x, y].x = x;
                graph[x, y].y = y;
            }
        }

        //finds if the tiles has neighbours 
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeX; y++)
            {
                if (x > 0)
                    graph[x, y].neighbours.Add(graph[x - 1, y]);
                if (x < mapSizeX - 1)
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                if (y > 0)
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                if (y < mapSizeY - 1)
                    graph[x, y].neighbours.Add(graph[x, y + 1]);
            }
        }
    }

    //generates teh map with the type of tile
    void GenerateMap()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeX; y++)
            {
                TileType tt = tileTypes[Tiles[x, y]];
                GameObject go = Instantiate(tt.CubePrefab, new Vector3(x, y, 0), Quaternion.identity);
               // ClickableTile ct = go.GetComponent<ClickableTile>();
                //ct.tileX = x;
                //ct.tileY = y;
                //ct.map = this;
            }
        }
    }

    //converts the coord from the tile and array to the world coord
    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    //checks if you can enter the tile
    public bool CanEnterTile(int x, int y)
    {
        return tileTypes[Tiles[x, y]].isWalkable;
    }

    //checks if the tile is clean or not
    public bool IsTileClean(int x, int y)
    {
        return tileTypes[Tiles[x, y]].isClean;
    }


    //uses dijikstra algorithm to find the shortest path to tile
    //public void GeneratePathTo(int x, int y)
    //{
    //    selectedUnit.GetComponent<Unit1>().currentPath = null;

        

    //    if(CanEnterTile(x,y) == false)
    //    {
    //        return;
    //    }

    //    Dictionary<puzzleNode, float> dist = new Dictionary<puzzleNode, float>();
    //    Dictionary<puzzleNode, puzzleNode> prev = new Dictionary<puzzleNode, puzzleNode>();

    //    List<puzzleNode> unvisted = new List<puzzleNode>();

    //    puzzleNode source = graph[selectedUnit.GetComponent<Unit1>().tileX,selectedUnit.GetComponent<Unit1>().tileY];
    //    puzzleNode target = graph[x, y];

    //    dist[source] = 0;
    //    prev[source] = null;

    //    foreach (puzzleNode v in graph)
    //    {
    //        if (v != source)
    //        {
    //            dist[v] = Mathf.Infinity;
    //            prev[v] = null;
    //        }
    //        unvisted.Add(v);
    //    }

    //    while (unvisted.Count > 0)
    //    {
    //        puzzleNode u = null;
    //        foreach (puzzleNode possibleU in unvisted)
    //        {
    //            if (u == null || dist[possibleU] < dist[u])
    //                u = possibleU;
    //        }
    //        if (u == target)
    //        {
    //            break;
    //        }
    //        unvisted.Remove(u);

    //        foreach(puzzleNode v in u.neighbours)
    //        {
    //            float alt = dist[u] + CostToEnterTile(v.x,v.y);
    //            if(alt < dist[v])
    //            {
    //                dist[v] = alt;
    //                prev[v] = u;
    //            }
    //        }
    //    }

    //    if (prev[target] == null)
    //    {
    //        return;
    //    }

    //    List<puzzleNode> currentPath = new List<puzzleNode>();

    //    puzzleNode curr = target;

    //    while (curr != null)
    //    {
    //        currentPath.Add(curr);
    //        curr = prev[curr];
    //    }

    //    currentPath.Reverse();

    //    selectedUnit.GetComponent<Unit1>().currentPath = currentPath;
    //}
}

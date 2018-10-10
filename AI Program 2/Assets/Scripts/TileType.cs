using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType
{

    public string name;
    public GameObject CubePrefab;

    public float movementCost = 1;
    public bool isWalkable = true;
    public bool isClean = true;

}

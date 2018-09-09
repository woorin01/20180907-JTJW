using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerated : MonoBehaviour {

    // Use this for initialization
    public Transform tile;
    public int iMapSize;
    
    void Start () 
    {
        CreateMap();
    }
    void CreateMap()
    {
        string HolderName = "MapChild";

        if ( transform.FindChild(HolderName) )
            DestroyImmediate(transform.FindChild(HolderName).gameObject);

        Transform MapHolder = new GameObject(HolderName).transform;
        MapHolder.parent    = transform; 

        Vector3 v3CreatePos = new Vector3(0f, 0f, 0f);
        for (int size = 0; size < iMapSize; size++)
        {
            Transform createTile    = Instantiate(tile, transform) as Transform;
            createTile.position     = v3CreatePos;
            createTile.parent       = MapHolder;

            v3CreatePos.z           += 4;
        }
    }
}

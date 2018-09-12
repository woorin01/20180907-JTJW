using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    // 생성할 타일
    public GameObject gTileObject;

    // 타일 하나를 생성할 좌표
    public Vector3 v3NowCreatePos;

    // 현재 생선된 타일의 갯수
    public int iGeneratedTile;
   
    // 버튼을 누르면 몇개를 생성할것인지
    public int iCreateAmount;

    public void CreateTile()
    {
        if (!transform.Find("TileHolder"))
            return;

        Transform Ge = transform.Find("TileHolder");

        for (int i = 0; i < iCreateAmount; i++)
        {
            v3NowCreatePos.z = 6 * iGeneratedTile;

            Instantiate(gTileObject, Ge).transform.position = v3NowCreatePos;

            iGeneratedTile++;
        }
    }

    public void CheckHolderInstance()
    {
        if (!transform.Find("TileHolder"))
        {
            GameObject TileHolder       = new GameObject("TileHolder");
            TileHolder.transform.parent = transform;

            v3NowCreatePos = new Vector3(0, 0, 0);
        }
    }

    public void RenewalGeneratoedTile()
    {
        if (!transform.Find("TileHolder"))
        {
            iGeneratedTile = 0;
            return;
        }

        iGeneratedTile = transform.Find("TileHolder").childCount;
    }
}

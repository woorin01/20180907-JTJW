using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapEditor : Editor {

    public override void OnInspectorGUI()   //OnInspectorGUI 에 오버라이드 해 줍니다.
    {
        base.OnInspectorGUI();

        MapGenerator ge = target as MapGenerator;

        ge.CheckHolderInstance();

        if (GUILayout.Button("PushTileBack"))
        {
            if (ge)
                ge.CreateTile();
        }

        ge.RenewalGeneratoedTile();
    }
}

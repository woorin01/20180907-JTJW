using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;

    public Vector3 v3TargetCmaeraPos;

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x + v3TargetCmaeraPos.x, v3TargetCmaeraPos.y, target.position.z + v3TargetCmaeraPos.z);
        
	}
}

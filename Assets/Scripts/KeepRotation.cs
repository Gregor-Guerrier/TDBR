using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KeepRotation : MonoBehaviour {

    private Quaternion rot;
    
	// Use this for initialization
	void Start () {
		rot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		transform.rotation = rot;
	}
}

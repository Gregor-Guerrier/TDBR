using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkManager : NetworkBehaviour {
	
	public GameObject[] toDestroy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			for (int i = 0; i < toDestroy.Length; i++)
			{
				Destroy(toDestroy[i]);
			}
		}
	}
}

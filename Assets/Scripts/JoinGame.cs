using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {
	
	List<Transform> roomList = new List<Transform>();

	// Use this for initialization
	void Start () {
		UnityEngine.Networking.NetworkManager.singleton.StartMatchMaker();
		
	}
	
	// Update is called once per frame

	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
	
	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;
	private RoomOptions roomOptions;
	private TypedLobby typedLobby;
	private string[] WhatisThis;

	void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

	public void CreateRoom()
	{
		PhotonNetwork.CreateRoom(roomName + System.Guid.NewGuid().ToString("N"), roomOptions, typedLobby, WhatisThis);
		Debug.Log("Created room called " + roomName);
	}

	public void JoinRoom()
	{
		for (int i = 0; i < roomsList.Length; i++)
            {
                    PhotonNetwork.JoinRoom(roomsList[i].name);
            }
	}

	
}

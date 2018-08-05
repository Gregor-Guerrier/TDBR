using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class HostGame : MonoBehaviour {
	
	[SerializeField]
	private uint roomSize = 6;
	[SerializeField]
	private Text input;
	[SerializeField]
	private Text ready;
	private bool readied;
	private UnityEngine.Networking.Types.NetworkID netID;
	private int matchNumber;
	private int matchCount;
	private string roomName;
	private UnityEngine.Networking.NetworkManager networkManager;
	public UnityEngine.Networking.Match.MatchInfo matchInfo;



	// Use this for initialization
	void Start () {
			ready.text = "Ready";
			networkManager = UnityEngine.Networking.NetworkManager.singleton;
			if(networkManager.matchMaker == null){
				networkManager.StartMatchMaker();
			}
			
	}
	
	public void OnCreateAttempt(){
		Debug.Log ("Processing...");
		Debug.Log ("Successful");
		networkManager.matchMaker.CreateMatch(input.text, roomSize, true, "", "", "", 0, 0, UnityEngine.Networking.NetworkManager.singleton.OnMatchCreate);
	
		

	}

	public void OnClicked(){
		readied = !readied;
		Debug.Log("Clicked");
		OnListClicked();

	}

	public void OnListClicked(){
		networkManager.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);

	}
	public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
		matchCount = matches.Count;
        if (matches.Count > 0)
        netID = matches[0].networkId; // This is the first match networkId
		CheckUp();
		for(int i = 0; i == matches.Count; i++){
			netID = matches[0].networkId;
			matchNumber = i;
			networkManager.matchMaker.JoinMatch(matches[matches.Count - 1].networkId, "" , "", "", 0, 0, OnMatchJoined);
			CheckUp();
		}
    }
	public void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        
    }
	public void CheckUp(){
		if (matchNumber == matchCount){
			Debug.Log("Could not find a game");
			OnCreateAttempt();
		}
	}
	void Update(){
		if(readied == true){
			ready.text = "Unready";
		}
		else
		{
			ready.text = "Ready";
		}
	}


	// Update is called once per frame
}

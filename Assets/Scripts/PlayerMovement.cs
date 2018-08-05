using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
    
		public float speed;
		public Camera cam;
		private PlayerInput pi;
	
		
		void Start(){
				pi = gameObject.GetComponent<PlayerInput>();
		}
		
		void Update(){
		
			if(!isLocalPlayer)
			{
				cam.enabled = false;
				return;
			}
		
		
			var pixelTarget = Input.mousePosition;
			var target = Camera.main.ScreenToWorldPoint(pixelTarget);
			Vector2 deltaPos = target - this.transform.position;
			this.transform.right = deltaPos.normalized;

		}
		public void TryMove(Vector2 input)
		{
			Debug.Log("Trying to move");
			this.transform.Translate(input * this.speed, Space.World);
		}
	
}
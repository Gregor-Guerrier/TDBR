using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	[SerializeField]
	private int speed;
	private float horizontal;
	private float vertical;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(horizontal, 0, vertical) * speed);
	}
}

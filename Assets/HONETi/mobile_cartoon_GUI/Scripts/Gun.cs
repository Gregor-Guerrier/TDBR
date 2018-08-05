using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	
	[SerializeField]
	private GunClass gun;
	private bool canFire;
	private float timePassed;
	private Animator animator;
	private bool Firing;
	private bool Reloading;
	private bool Idle;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		canFire = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButton("Fire1") && canFire){
			Shoot();
			canFire = false;
		}

		if(Input.GetKeyDown(KeyCode.R)){
			animator.SetBool("Reload", true);
			animator.SetBool("Fire", false);
			animator.SetBool("Reload", false);
			animator.SetBool("Idle", true);
		}
	}

	void Shoot () {
		animator.SetBool("Reload", false);
		animator.SetBool("Fire", true);
		animator.SetBool("Fire", false);
		animator.SetBool("Idle", true);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour {
	
	public PlayerShoot ps;
	public PlayerMovement pm;
	
	// Use this for initialization
	void Start () {
		pm = gameObject.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			return;
		}
		
		if (Input.GetButtonDown("Fire1") && ps.pickedup.auto == false && ps.timedelayed >= ps.pickedup.firerate)
        {
            CmdFire();
            
        }
		if (Input.GetButton("Fire1") && ps.pickedup.auto == true && ps.timedelayed >= ps.pickedup.firerate)
        {   
            CmdFire();

		}
		//Shoots on the network if it is able to
		if (Input.GetButton("Fire1") && ps.CanFire)
        {   
            CmdFire();

		}
		
		Vector2 input = new Vector2(
		Input.GetAxis("Horizontal"),
		Input.GetAxis("Vertical"));
		pm.TryMove(input);

		
	}
	
	[Command]
    void CmdFire()
    {
		
		ps.Shoot();
        
    }
}

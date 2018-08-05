using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : MonoBehaviour {
    
	public GunClass pickedup;
    public float timedelayed;
    private int AmmoInBags;
	private int AmmoInMagazines;
    private GameObject g;
    private PlayerShoot owner;
	public bool CanFire;
	
    
	// Use this for initialization
	void Start () {
	AmmoInMagazines = pickedup.magazineSize;
	}
	
	// Update is called once per frame
	

    

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    

	void Update(){
		if(timedelayed >= pickedup.firerate){
			CanFire = true;
		} else if (timedelayed < pickedup.firerate)
		{
			CanFire = false;
		}
		timedelayed += Time.deltaTime;
	
 
		if(AmmoInMagazines == 0){
     
		}
	}
	public void Shoot(){
			Debug.Log("Phase #1");
			var rotationZ = pickedup.barrel.rotation.eulerAngles.z;
			rotationZ += Random.Range(-pickedup.spread, pickedup.spread);
			var rot = Quaternion.Euler( 0, 0, rotationZ);
			Debug.Log("Phase #2");
			Bullet instance = Instantiate(pickedup.bullet, pickedup.barrel.position, rot);
			instance.GetComponent<Rigidbody2D>().velocity = instance.transform.forward * pickedup.velocity;
			instance.GetComponent<Bullet>().damage = pickedup.damage;
			instance.Fire(this);
			Debug.Log("Phase #3");
			timedelayed = 0;
			AmmoInMagazines--;
			
			NetworkServer.Spawn(instance.gameObject);
        // Create the Bullet from the Bullet Prefab
	}
	
	
}

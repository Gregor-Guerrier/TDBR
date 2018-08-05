using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private Rigidbody2D rb;
    public int LiveTime;
    private float timelived;
    public int speed;
    public PlayerShoot owner;
    private float forceMagnitude;
	public float damage;
    
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		timelived += Time.deltaTime;
		if (timelived >= LiveTime){
		    Destroy(gameObject);
		}
	}
	public void Fire(PlayerShoot owner)
{
    this.owner = owner;
    Debug.Log(owner.gameObject.name);
}
}

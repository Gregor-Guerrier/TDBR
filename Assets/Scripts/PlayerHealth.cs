using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : MonoBehaviour {
	
	private float health;
	private float armor;
	public Image hp;
	public Image ap;
	public Text aa;
	public Text ha;
	
	// Use this for initialization
	void Start () {
		health = 100;
		armor = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ha.text = "" + health;
		aa.text = "" + armor;
		hp.fillAmount = health / 100;
		ap.fillAmount = armor / 100;
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var bullet = collision.gameObject.GetComponent<Bullet>();
		if (bullet)
		{
			var unappliedDamage = bullet.damage;
			if (this.armor > 0f)
			{
				this.armor -= unappliedDamage;
				if (this.armor < 0f)
				{
					unappliedDamage = -this.armor;
					this.armor = 0f;
				}
				else
				{
					unappliedDamage = 0f;
					
				}
			}

			if (unappliedDamage > 0f && armor == 0)
			{
				this.health -= unappliedDamage;
				if (this.health <= 0f)
				{
                // Handle player death
				}
			}
			NetworkServer.Destroy(bullet.gameObject);
		}
	}
}

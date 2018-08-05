using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun Class", order = 1)]
public class GunClass : ScriptableObject {
		public string gunName;
		public Transform gun;
		public Transform barrel;
		public Bullet bullet;
		public ParticleSystem muzzleFlash;
		public int magazineSize;
		public float firerate;
		public float damage;
		public float spread;
		public float velocity;
		public bool auto;
}
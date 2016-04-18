using UnityEngine;
using System.Collections;

public class Enemy5ShootScript : MonoBehaviour {

	public bool shooting = true;
	public Rigidbody2D enemyWeaponRigidBody;
	public float bulletSpeed = 19.0f;
	public float fireRate = 1.0f;
	private float lastShoot = 0f;

	// Update is called once per frame
	void Update () {
		if(shooting) {
			if (Time.time > fireRate + lastShoot) {
				BulletMove();
				lastShoot = Time.time;
			}
		}
	}

	private void BulletMove() {
		if (this.GetComponentInParent<Enemy5Patrol> ().GetWalkingDirection() > 0) {
			Rigidbody2D bulletInstance = Instantiate (enemyWeaponRigidBody, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (bulletSpeed, 0);
		} else {
			Rigidbody2D bulletInstance = Instantiate (enemyWeaponRigidBody, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (-bulletSpeed, 0);
		}
	}
}

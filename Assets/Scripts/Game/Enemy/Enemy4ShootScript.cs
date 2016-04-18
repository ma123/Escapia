using UnityEngine;
using System.Collections;

public class Enemy4ShootScript : MonoBehaviour {

	public bool shooting = true;
	public Rigidbody2D enemyWeaponRigidBody;
	public float bulletSpeed = 19.0f;
	public float fireRate = 1.0f;
	private float lastShoot = 0f;
	public bool direction = true;

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
		if(direction) {
			Rigidbody2D bulletInstance = Instantiate (enemyWeaponRigidBody, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (-bulletSpeed, 0);
		} else {
			Rigidbody2D bulletInstance = Instantiate (enemyWeaponRigidBody, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2 (bulletSpeed, 0);
		}
	}
}

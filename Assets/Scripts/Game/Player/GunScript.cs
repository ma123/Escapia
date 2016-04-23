using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {
	public Rigidbody2D boneBulletRigidBody;
	public float speed = 10f;				// rychlost projektilu
	private float fireRate = 0.5f;
	private float lastShoot = 0f;

	private GameObject player;		// Reference to the PlayerControl script.
	
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		

	public void Shoot() {  
		if (Time.time > fireRate + lastShoot) {
			if(ScoreScript.GetMoney() > 0) {
				BulletMove ();
				ScoreScript.RemoveScore (1);
			} 
			lastShoot = Time.time;
		}
	}

	private void BulletMove() {
		if(player.GetComponent<PlayerControllerScript>().GetFacingRight()) {
			Rigidbody2D bulletInstance = Instantiate(boneBulletRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
		else {
			Rigidbody2D bulletInstance = Instantiate(boneBulletRigidBody, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, 0);
		}
	}
}

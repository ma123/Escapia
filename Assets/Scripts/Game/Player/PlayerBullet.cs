﻿using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	private int gunStrength = 1;
	private float zRotate = 0.0f;

	void Start () {
		Destroy(gameObject, 1.0f); // znicenie naboja po 3 sekundach ak nenajde ciel
	}

	void FixedUpdate() {
		gameObject.transform.Rotate(new Vector3(0,0, zRotate));
		zRotate++;
		print (zRotate);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy1") {
			col.GetComponent<Enemy1Patrol> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		}

		if (col.tag == "Enemy2") {
			col.GetComponent<Enemy2Patrol> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		}

		if (col.tag == "Enemy3") {
			col.GetComponent<Enemy3Static> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		}

		if (col.tag == "Enemy4") {
			col.GetComponent<Enemy4Static> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		}

		if (col.tag == "Enemy5") {
			col.GetComponent<Enemy5Patrol> ().EnemyHit (gunStrength);
			Destroy (gameObject);
		}
			
		if (col.tag == "Wall") {
				Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Enemy4Static : MonoBehaviour {
	public int enemyHP = 2;
	public float attackStrength = 20;
	public int enemyGain = 2;
	public GameObject enemyDeadParticle;

	public void EnemyReact () {
		GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
		health.GetComponent<HealthScript> ().Hit (attackStrength);
	}

	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			Destroy (Instantiate(enemyDeadParticle, transform.position, Quaternion.identity), 2.0f);
			Destroy (gameObject);
			ScoreScript.AddScore(enemyGain);
		}
	}
}

using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
	public int attackDamage = 1;

	void Start() {
		attackDamage = PlayerPrefs.GetInt ("attack", 1);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if((col.isTrigger != true) && col.CompareTag("Enemy")) {
			col.GetComponent<EnemyPatrolHole> ().EnemyHit (attackDamage);
		}
	}
}

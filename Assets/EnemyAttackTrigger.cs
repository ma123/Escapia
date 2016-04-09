using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour {
	public float attackDamage = 20;

	void OnTriggerEnter2D(Collider2D col) {
		if((col.isTrigger != true) && col.CompareTag("Player")) {
			GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
			health.GetComponent<HealthScript> ().Hit (attackDamage);
		}
	}
}

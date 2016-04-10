using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour {
	public float attackDamage = 20;
	public bool lockAttack = true;

	void OnTriggerEnter2D(Collider2D col) {
		if((col.isTrigger != true) && col.CompareTag("Player")) {
			if(lockAttack) {
				lockAttack = false;
				GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
				health.GetComponent<HealthScript> ().Hit (attackDamage);
				StartCoroutine(Wait());
			}
		}
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(1);
		lockAttack = true;
	}
}

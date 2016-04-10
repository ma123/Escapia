using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
	public int attackDamage = 1;
	public bool lockAttack = true;

	void Start() {
		attackDamage = PlayerPrefs.GetInt ("attack", 1);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (lockAttack) {
			if ((col.isTrigger != true) && col.CompareTag ("Enemy1")) {
				lockAttack = false;
				col.GetComponent<Enemy1Patrol> ().EnemyHit (attackDamage);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy2")) {
				lockAttack = false;
				col.GetComponent<Enemy2Patrol> ().EnemyHit (attackDamage);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy3")) {
				lockAttack = false;
				col.GetComponent<Enemy3Static> ().EnemyHit (attackDamage);
			}
			StartCoroutine(Wait());
		}
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(1);
		lockAttack = true;
	}
}

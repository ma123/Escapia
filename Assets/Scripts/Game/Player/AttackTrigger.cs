using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
	public int attackDamage = 1;
	public float attackCD = 0.4f;
	public bool lockAttack = true;
	public GameObject attackParticle;

	void Start() {
		attackDamage = PlayerPrefs.GetInt ("attack", 1);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (lockAttack) {
			if ((col.isTrigger != true) && col.CompareTag ("Enemy1")) {
				col.GetComponent<Enemy1Patrol> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy2")) {
				col.GetComponent<Enemy2Patrol> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy3")) {
				col.GetComponent<Enemy3Static> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy4")) {
				col.GetComponent<Enemy4Static> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("Enemy5")) {
				col.GetComponent<Enemy5Patrol> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("LeviathanHearth")) {
				col.GetComponent<LeviathanHearth> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}

			if ((col.isTrigger != true) && col.CompareTag ("LeviathanBoss")) {
				col.GetComponent<LeviathanHearth> ().EnemyHit (attackDamage);
				Instantiate(attackParticle, transform.position, Quaternion.identity);
			}
			lockAttack = false;

			StartCoroutine(Wait());
		}
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(attackCD);
		lockAttack = true;
	}
}

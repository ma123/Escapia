using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour {
	public float attackDamage = 20;
	public bool lockAttack = true;
	private GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D col) {
		if((col.isTrigger != true) && col.CompareTag("Player")) {
			if(lockAttack) {
				lockAttack = false;
				GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
				health.GetComponent<HealthScript> ().Hit (attackDamage);
				player.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				Vector2 newPosition = new Vector2 (player.transform.position.x - 1f, player.transform.position.y + 1f);
				player.transform.position = newPosition;
				StartCoroutine(Wait());
			}
		}
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(1);
		lockAttack = true;
		player.GetComponent<SpriteRenderer> ().color = Color.white; // zafarbenie hraca na povodnu farbu
	}
}

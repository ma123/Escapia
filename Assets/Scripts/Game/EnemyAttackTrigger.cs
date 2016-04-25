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
				Vector2 newPosition;
				health.GetComponent<HealthScript> ().Hit (attackDamage);
				player.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				if(player.GetComponent<PlayerControllerScript>().GetFacingRight()) {
					newPosition = new Vector2 (this.transform.position.x - 1f, this.transform.position.y + 1f);
				} else {
					newPosition = new Vector2 (this.transform.position.x + 1f, this.transform.position.y + 1f);
				}
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

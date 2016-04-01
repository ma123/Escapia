using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	public int attackDamage = 20;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.isTrigger != true && col.CompareTag("Enemy")) {
			// damage enemy todo
		}
	}
}

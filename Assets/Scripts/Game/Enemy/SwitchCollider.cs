using UnityEngine;
using System.Collections;

public class SwitchCollider : MonoBehaviour {
	private bool switchCollider = false;

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Player")) {
			switchCollider = true;
		}
	}

	public bool GetSwitchCollider() {
		return switchCollider;
	}
}

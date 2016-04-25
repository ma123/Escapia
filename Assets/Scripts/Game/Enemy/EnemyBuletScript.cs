using UnityEngine;
using System.Collections;

public class EnemyBuletScript : MonoBehaviour {
	public float gunStrength = 20;
	
	void Start () {
		Destroy(gameObject, 3); // znicenie naboja po 2 sekundach ak nenajde ciel
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
			health.GetComponent<HealthScript> ().Hit (gunStrength);

			Destroy (gameObject);
		} else {
			if (col.tag == "Wall") {
				Destroy (gameObject);
			}
		}
	}
}

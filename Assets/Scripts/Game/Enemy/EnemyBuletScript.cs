using UnityEngine;
using System.Collections;

public class EnemyBuletScript : MonoBehaviour {
	private int gunStrength = 30;
	
	void Start () {
		Destroy(gameObject, 2); // znicenie naboja po 2 sekundach ak nenajde ciel
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			print ("shoot player");
			HealthScript.Hit (gunStrength);
			Destroy (gameObject);
		} else {
			if (col.tag != "Enemy" && col.tag != "Boss" && col.tag != "Life" && col.tag != "Munition" && col.tag != "EndLevel" && col.tag != "Coin" && col.tag != "Spike" ) {
				Destroy (gameObject);
			}
		}
	}
}

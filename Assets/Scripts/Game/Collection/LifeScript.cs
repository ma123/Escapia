using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {
	public void LifeReact () {
		//Destroy(Instantiate (parts, transform.position, Quaternion.identity), 2); // po 2 sekundach sa znici particle system
		GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
		health.GetComponent<HealthScript> ().AddHealth (50f);
		Destroy (gameObject);
	}
}

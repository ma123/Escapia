using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {
	public void LifeReact () {
		print ("destroy object life");
		//Destroy(Instantiate (parts, transform.position, Quaternion.identity), 2); // po 2 sekundach sa znici particle system
		HealthScript.AddHealth (50);
		Destroy (gameObject);
	}
}

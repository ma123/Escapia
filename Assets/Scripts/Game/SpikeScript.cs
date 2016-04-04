using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	public void SpikeReact() {
		GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
		health.GetComponent<HealthScript> ().Hit(100f);
	}
}

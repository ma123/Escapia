using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	public void SpikeReact() {
		HealthScript.Hit (100);
	}
}

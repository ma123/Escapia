using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour {
	private Rigidbody2D rigidBodyPlayer;
	public float trampolineStrength = 600f;

	void Start() {
		rigidBodyPlayer = GetComponent<Rigidbody2D> ();
	}

	public void TrampolineReact() {
		print ("trampoline object collision");
		GameObject player = GameObject.Find ("Player");
		rigidBodyPlayer = player.GetComponent<Rigidbody2D> ();
		rigidBodyPlayer.AddForce (new Vector2 (0f, trampolineStrength), ForceMode2D.Force);   // prida v rigidbody Vektor2 y osi silu jumpForce
	}
}

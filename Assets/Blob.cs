using UnityEngine;
using System.Collections;

public class Blob : MonoBehaviour {
	private Rigidbody2D rigid; 	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Player")) {
			rigid.AddForce (new Vector2(500f, 500f));
		}
	}
}

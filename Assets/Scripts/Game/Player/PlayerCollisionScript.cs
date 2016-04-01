using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	public static bool damageLock = true;
	private float waitTime = 2f;
	private float lastTime = 0f;

	public AudioClip ouchClips;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy")) {
			GameObject enemy = coll.collider.gameObject;

			if (Time.time > waitTime + lastTime) {
				if(damageLock) {
					damageLock = false;

					//Vector2 hurtVector = transform.position - coll.transform.position + Vector2.up * 5f;

					AudioSource.PlayClipAtPoint(ouchClips, transform.position);
				    this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0f, 200f));   // prida v rigidbody Vektor2 y osi silu jumpForce

					enemy.GetComponent<EnemyScript> ().EnemyReact();
					damageLock = true;  
				}
				lastTime = Time.time;
			}
		}

		if (coll.collider.CompareTag ("Trampoline")) {
			GameObject trampoline = coll.collider.gameObject;
			trampoline.GetComponent<TrampolineScript> ().TrampolineReact ();
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy")) {
			GameObject enemy = coll.collider.gameObject;
			
			if (Time.time > waitTime + lastTime) {
				if(damageLock) {
					damageLock = false;
					AudioSource.PlayClipAtPoint(ouchClips, transform.position);
					enemy.GetComponent<EnemyScript> ().EnemyReact();
					damageLock = true;  
				}
				lastTime = Time.time;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			coin.GetComponent<CoinScript> ().CoinReact();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Life")) {
			GameObject life = coll.GetComponent<Collider2D>().gameObject;
			life.GetComponent<LifeScript> ().LifeReact();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Spike")) {
			GameObject spike = coll.GetComponent<Collider2D>().gameObject;
			spike.GetComponent<SpikeScript> ().SpikeReact ();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("EndLevel")) {
			GameObject endLevel = coll.GetComponent<Collider2D>().gameObject;
			endLevel.GetComponent<EndLevelScript> ().EndLevelReact();
		}
	}
}

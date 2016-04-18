using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	public static bool damageLock = true;
	private bool jumpLock = false;
	private float waitTime = 1f;
	private Vector2 backForce = new Vector2(-2000.0f, 200.0f);

	void Start() {
		damageLock = true;
	}

	void FixedUpdate() {
		if(damageLock) {
			this.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		if(jumpLock) {
			this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
			jumpLock = false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy1")) {
			GameObject enemy = coll.collider.gameObject;
				if (damageLock) {
					damageLock = false;
					this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
					StartCoroutine (Wait());
					jumpLock = true;
					//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
					enemy.GetComponent<Enemy1Patrol> ().EnemyReact ();
				}
		}

		if (coll.collider.CompareTag ("Enemy2")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
				enemy.GetComponent<Enemy2Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy3")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
				enemy.GetComponent<Enemy3Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy4")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);

				enemy.GetComponent<Enemy4Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy5")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//enemy.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);

				enemy.GetComponent<Enemy5Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Trampoline")) {
			GameObject trampoline = coll.collider.gameObject;
			trampoline.GetComponent<TrampolineScript> ().TrampolineReact ();
		}
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(waitTime);
		damageLock = true;
	}

	void OnCollisionStay2D(Collision2D coll) {
		/*if (coll.collider.CompareTag ("Enemy1")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
				enemy.GetComponent<Enemy1Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy2")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
				enemy.GetComponent<Enemy2Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy3")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);
				enemy.GetComponent<Enemy3Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy4")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//this.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);

				enemy.GetComponent<Enemy4Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy5")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				damageLock = false;
				this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
				StartCoroutine (Wait());
				jumpLock = true;
				//enemy.GetComponent<Rigidbody2D> ().AddForce (backForce, ForceMode2D.Force);

				enemy.GetComponent<Enemy5Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Trampoline")) {
			GameObject trampoline = coll.collider.gameObject;
			trampoline.GetComponent<TrampolineScript> ().TrampolineReact ();
		}*/
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.GetComponent<Collider2D>().CompareTag("Coin")) {
			GameObject coin = coll.GetComponent<Collider2D>().gameObject;
			this.GetComponentInChildren<SoundsAndMusicScript> ().PickupBone (transform);
			coin.GetComponent<CoinScript> ().CoinReact();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Life")) {
			GameObject life = coll.GetComponent<Collider2D>().gameObject;
			this.GetComponentInChildren<SoundsAndMusicScript> ().PickupLife (transform);
			life.GetComponent<LifeScript> ().LifeReact();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("Spike")) {
			GameObject spike = coll.GetComponent<Collider2D>().gameObject;
			spike.GetComponent<SpikeScript> ().SpikeReact ();
		}

		if(coll.GetComponent<Collider2D>().CompareTag("EndLevel")) {
			GameObject endLevel = coll.GetComponent<Collider2D>().gameObject;
			this.GetComponentInChildren<SoundsAndMusicScript> ().WinnSound (transform);
			endLevel.GetComponent<EndLevelScript> ().EndLevelReact();
		}
	}
}
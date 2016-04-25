using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	public static bool damageLock = true;
	private float waitTime = 1f;

	void Start() {
		damageLock = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Enemy1")) {
			GameObject enemy = coll.collider.gameObject;
				if (damageLock) {
					DamageLock ();
					enemy.GetComponent<Enemy1Patrol> ().EnemyReact ();
				}
		}

		if (coll.collider.CompareTag ("Enemy2")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<Enemy2Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy3")) {
			GameObject enemy = coll.collider.gameObject;

			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<Enemy3Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy4")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<Enemy4Static> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Enemy5")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<Enemy5Patrol> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("LeviathanHearth")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<LeviathanHearth> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("LeviathanBoss")) {
			GameObject enemy = coll.collider.gameObject;
			if (damageLock) {
				DamageLock ();
				enemy.GetComponent<BossScript> ().EnemyReact ();
			}
		}

		if (coll.collider.CompareTag ("Trampoline")) {
			GameObject trampoline = coll.collider.gameObject;
			trampoline.GetComponent<TrampolineScript> ().TrampolineReact ();
		}
	}

	void DamageLock() {
		damageLock = false;
		Vector2 newPosition;
		this.GetComponent<SpriteRenderer> ().color = Color.red; // zafarbenie hraca na cerveno
		StartCoroutine (Wait());
		if(this.GetComponent<PlayerControllerScript>().GetFacingRight()) {
			newPosition = new Vector2 (this.transform.position.x - 1f, this.transform.position.y + 1f);
		} else {
			newPosition = new Vector2 (this.transform.position.x + 1f, this.transform.position.y + 1f);
		}
		this.transform.position = newPosition;
	}

	IEnumerator Wait() { 
		yield return new WaitForSeconds(waitTime);
		damageLock = true;
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void OnCollisionStay2D(Collision2D coll) {
		// todo keby daco
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
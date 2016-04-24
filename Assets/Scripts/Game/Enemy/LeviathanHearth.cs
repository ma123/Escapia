using UnityEngine;
using System.Collections;

public class LeviathanHearth : MonoBehaviour {
	public int enemyHP = 2;
	public float attackStrength = 20;
	public int enemyGain = 2;
	public int hearthNumber = 0;

	private BoxCollider2D enemyCollision;
	private Rigidbody2D enemyRigidbody;

	private bool walking = true;
	private bool attacking = false;
	private float attackTimer = 0f;
	private float attackCD = 1.0f;
	public Collider2D attackTrigger;
	public float waitAttack = 3.0f;
	private float lastTime = 0.0f;

	void Start () {
		enemyCollision = GetComponent<BoxCollider2D> ();
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		attackTrigger.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(walking) {
			Attack();	
		}

		if(attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		} 
	}

	public void Attack() {
		if (Time.time > waitAttack + lastTime) {
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.enabled = true;
			lastTime = Time.time;
		}
	}

	public void EnemyReact () {
		GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
		health.GetComponent<HealthScript> ().Hit (attackStrength);
	}

	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			walking = false;
			this.gameObject.tag = "Untagged";
			enemyRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			enemyCollision.isTrigger = true;

			ScoreScript.AddScore(enemyGain);
		}
	}

	public int GetHearthNumber() {
		return hearthNumber;
	}
}

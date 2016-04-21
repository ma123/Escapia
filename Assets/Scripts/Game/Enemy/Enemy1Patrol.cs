using UnityEngine;
using System.Collections;

public class Enemy1Patrol : MonoBehaviour {
	public int enemyHP = 1;
	public float attackStrength = 20;
	public int enemyGain = 1;

	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	private float walkingDirection = -1.0f;
	private Vector2 walkAmount;
	private float originalX; // Original float value
	private Animator anim;
	private bool walking = true;
	private BoxCollider2D enemyCollision;
	private Rigidbody2D enemyRigidbody;
	public float xColliderSize = 2.236092f;
	public float yColliderSize = 0.7475041f;
	public float xCollOff = 0.0f;
	public float yCollOff = 0.0f;
	public float downOff = 0.5f;
	public bool isTrigger = false;

	void Start () {
		this.originalX = this.transform.position.x;
		anim = GetComponent<Animator>();
		enemyCollision = GetComponent<BoxCollider2D> ();
		enemyRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (walking) {
			walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
			if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {
				walkingDirection = -1.0f;
				Flip ();
			} else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
				walkingDirection = 1.0f;
				Flip ();
			}
			transform.Translate (walkAmount);
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
			anim.SetBool ("Death",true);
			this.gameObject.tag = "Untagged";
			if (isTrigger) {
				enemyRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
				transform.position = new Vector2(transform.position.x, transform.position.y - downOff);
				enemyCollision.isTrigger = true;
			} else {
				enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

				enemyCollision.size = new Vector2 (xColliderSize, yColliderSize);
				enemyCollision.offset = new Vector2 (xCollOff, yCollOff);
			}

			ScoreScript.AddScore(enemyGain);
		}
	}

	private void Flip() {
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public float GetWalkingDirection() {
		return walkingDirection;
	}
}

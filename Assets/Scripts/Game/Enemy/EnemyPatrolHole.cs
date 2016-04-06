using UnityEngine;
using System.Collections;

public class EnemyPatrolHole : MonoBehaviour {
	public int enemyHP = 1;
	public float attackStrength = 20;

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
	private float xColliderSize = 2.236092f;
	private float yColliderSize = 0.7475041f;
	private float xColliderOffset = 0f;
	private float yColliderOffset = 0f;

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
			enemyRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
			//enemyCollision.isTrigger = true;
			//enemyRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;

			enemyCollision.size = new Vector2 (xColliderSize, yColliderSize);
			enemyCollision.offset = new Vector2 (xColliderOffset, yColliderOffset);
			ScoreScript.AddScore(1);
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

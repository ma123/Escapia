using UnityEngine;
using System.Collections;

public class Enemy2Patrol : MonoBehaviour {
		public int enemyHP = 2;
		public float attackStrength = 20;
		public int enemyGain = 2;

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

		private bool attacking = false;
		private float attackTimer = 0f;
		private float attackCD = 0.5f;
		public Collider2D attackTrigger;
		private float waitAttack = 2.0f;
		private float lastTime = 0.0f;

		void Start () {
			this.originalX = this.transform.position.x;
			anim = GetComponent<Animator>();
			enemyCollision = GetComponent<BoxCollider2D> ();
			enemyRigidbody = GetComponent<Rigidbody2D> ();
			attackTrigger.enabled = false;
		}

		// Update is called once per frame
		void Update () {
			if (walking) {
				walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
				Attack ();
				if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {
					walkingDirection = -1.0f;
					Flip ();
				} else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
					walkingDirection = 1.0f;
					Flip ();
				}
				transform.Translate (walkAmount);
			}

			if(attacking) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				} else {
					attacking = false;
					attackTrigger.enabled = false;
				}
			} 

			anim.SetBool ("Attack",attacking);
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
				anim.SetBool ("Death",true);
				this.gameObject.tag = "Untagged";
				if (isTrigger) {
					enemyRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

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

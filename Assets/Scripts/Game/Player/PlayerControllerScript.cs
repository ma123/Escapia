using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 7f; // max rychlost ktoru moze ziskat hrac na osi x
	public bool facingRight = true; // smer otocenia vpravo true
    private Animator anim;
	public Rigidbody2D rigidBodyPlayer;

	private float hInput = 0;

	// crouch
	BoxCollider2D playerCollision;
	bool bIsCrouched = false;
	float crouchHeight = 0.7f;
	float standHeight = 2.043831f;
	float crouchXOffset = -0.09972254f;
	float crouchYOffset = 0.0f;
	float standYOffset = 0.4100001f;

	private bool attacking = false;
	private float attackTimer = 0f;
	private float attackCD = 0.3f;
	private float waitAttack = 1.0f;
	private float lastTime = 0.0f;

	public Collider2D attackTrigger;

	void Start () {
		Time.timeScale = 1; // po spustenie skriptu timeScale na 1 abz pokracovala hra aj po restarte
		rigidBodyPlayer = GetComponent<Rigidbody2D> ();
		playerCollision = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator>();
		attackTrigger.enabled = false;
	}

	void Update () {
		Move (hInput);

		if(attacking) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				} else {
					attacking = false;
					attackTrigger.enabled = false;
				}
		} 
			
		anim.SetBool ("Attack",attacking);
		anim.SetBool ("Crouch", bIsCrouched);
	}

	public void Crouch() {
		if(hInput == 0) {
			bIsCrouched = true;
			playerCollision.size = new Vector2 (playerCollision.size.x, crouchHeight);
			playerCollision.offset = new Vector2 (crouchXOffset, crouchYOffset);
		}
	}

	public void StandUp() {
		if (hInput == 0) {
			bIsCrouched = false;
			playerCollision.size = new Vector2 (playerCollision.size.x, standHeight);
			playerCollision.offset = new Vector2 (crouchXOffset, standYOffset);
		}
	}
	
	// pohyb po osi x
	public void Move(float moveSpeed) {
		anim.SetFloat ("Speed", Mathf.Abs (moveSpeed));

		rigidBodyPlayer.velocity = new Vector2 (moveSpeed * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y); 

		if ((moveSpeed > 0) && !facingRight) {
			Flip ();
		} else { 
			if ((moveSpeed < 0) && facingRight) {
				Flip ();
			}
		}
	}

	// otocenie hraca
	private void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void StartMoving(float horizontalInput) {
		if(!bIsCrouched) {
			hInput = horizontalInput;
		}
	}

	public void Attack() {
		if(!bIsCrouched) {
			if (Time.time > waitAttack + lastTime) {
				this.GetComponentInChildren<SoundsAndMusicScript> ().AttackSound (transform);
				attacking = true;
				attackTimer = attackCD;
				attackTrigger.enabled = true;
				lastTime = Time.time;
			}
		}
	}

	public bool GetFacingRight() {
		return facingRight;
	}
}


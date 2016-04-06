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
	bool bIsCrouched = true;
	float crouchHeight = 0.7f;
	float standHeight = 2.043831f;
	float crouchXOffset = -0.09972254f;
	float crouchYOffset = 0.0f;
	float standYOffset = 0.4100001f;

	private bool attacking = false;
	private float attackTimer = 0f;
	private float attackCD = 0.3f;

	public Collider2D attackTrigger;

	void Start () {
		Time.timeScale = 1; // po spustenie skriptu timeScale na 1 abz pokracovala hra aj po restarte
		rigidBodyPlayer = GetComponent<Rigidbody2D> ();
		playerCollision = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator>();
		attackTrigger.enabled = false;
	}

	void FixedUpdate () {
		#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
			Move(Input.GetAxis ("Horizontal"));
			if(Input.GetKeyDown(KeyCode.Space)) {
				Crouch();
				if(Input.GetKeyUp(KeyCode.Space)) {
					StandUp();
				}	
			}

			if(Input.GetKeyDown("a") && !attacking) {
				Attack();
			}
        #else
		  Move (hInput);
        #endif

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

	public void Crouch() {
		bIsCrouched = true;
		playerCollision.size = new Vector2 (playerCollision.size.x, crouchHeight);
		playerCollision.offset = new Vector2 (crouchXOffset, crouchYOffset);
		anim.SetBool ("Crouch", bIsCrouched);
	}

	public void StandUp() {
		bIsCrouched = false;
		playerCollision.size = new Vector2 (playerCollision.size.x, standHeight);
		playerCollision.offset = new Vector2 (crouchXOffset, standYOffset);
		anim.SetBool ("Crouch", bIsCrouched);
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
		hInput = horizontalInput;
	}

	public void Attack() {
		attacking = true;
		attackTimer = attackCD;
		attackTrigger.enabled = true;
	}
}


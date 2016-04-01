using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float maxSpeed = 7f; // max rychlost ktoru moze ziskat hrac na osi x
	public bool facingRight = true; // smer otocenia vpravo true
	// private Animator anim;
	public Rigidbody2D rigidBodyPlayer;

	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround; 
	public float jumpForce = 400f;

	private bool doubleJump = false;
	private float hInput = 0;

	public AudioClip jumpClip;			// pole audioclip pri skoku

	// crouch
	BoxCollider2D playerCollision;
	bool bIsCrouched = true;
	float crouchHeight = 2.1f;
	float standHeight = 4.221554f;
	float crouchXOffset = -0.28f;
	float crouchYOffset = -0.47f;
	float standYOffset = 0.4f;


	void Start () {
		Time.timeScale = 1; // po spustenie skriptu timeScale na 1 abz pokracovala hra aj po restarte
		rigidBodyPlayer = GetComponent<Rigidbody2D> ();
		playerCollision = GetComponent<BoxCollider2D> ();
		//anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//anim.SetBool ("Ground", grounded);

		if (grounded) {
			doubleJump = false;
		}

		//anim.SetFloat ("Vspeed", rigidBodyPlayer.velocity.y);

		/*if (!grounded) {
			return;
		}*/
	
		#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
			Move(Input.GetAxis ("Horizontal"));

			if(Input.GetKeyDown(KeyCode.Space)) {
				Crouch();
			}
        #else
		  Move (hInput);
        #endif
	}


	/* Jednoskok dvojskok */
	public void Jump () {
		if (grounded || !doubleJump) { // ak je na zemi alebo nie je doublejump
			//anim.SetBool ("Ground", false);

			AudioSource.PlayClipAtPoint(jumpClip, transform.position); // prehranie jump zvuku

			rigidBodyPlayer.AddForce (new Vector2 (0, jumpForce));   // prida v rigidbody Vektor2 y osi silu jumpForce
		
			if (!doubleJump && !grounded) { // ak nieje doublejump a nie je na zemi moze spravit doublejump
				doubleJump = true;
			}
		}
	}

	public void Crouch() {
		bIsCrouched = true;
		playerCollision.size = new Vector2 (playerCollision.size.x, crouchHeight);
		playerCollision.offset = new Vector2 (crouchXOffset, crouchYOffset);
		//anim.SetTrigger("Crouch");
	}

	public void StandUp() {
		bIsCrouched = false;
		playerCollision.size = new Vector2 (playerCollision.size.x, standHeight);
		playerCollision.offset = new Vector2 (crouchXOffset, standYOffset);
	}
	
	// pohyb po osi x
	public void Move(float moveSpeed) {
		//anim.SetFloat ("Speed", Mathf.Abs (moveSpeed));

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
}

using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {
	public int enemyHP = 50;
	public float attackStrength = 20;
	
	public float walkSpeed = 1.0f;      // Walkspeed
	public float wallLeft = 0.0f;       // Define wallLeft
	public float wallRight = 5.0f;      // Define wallRight
	private float walkingDirection = 1.0f;
	private Vector2 walkAmount;
	private float originalX; // Original float value


	void Start () {
		this.originalX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
		if (walkingDirection > 0.0f && transform.position.x >= originalX + wallRight) {
			walkingDirection = -1.0f;
			Flip();
		} else if (walkingDirection < 0.0f && transform.position.x <= originalX - wallLeft) {
			walkingDirection = 1.0f;
			Flip ();
		}
		transform.Translate(walkAmount);
	}
	
	public void EnemyReact () {
		GameObject health = GameObject.FindGameObjectWithTag("HealthBarReact");
		health.GetComponent<HealthScript> ().Hit(attackStrength);
	}
	
	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			Destroy (gameObject);
			ScoreScript.AddScore(1000);
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

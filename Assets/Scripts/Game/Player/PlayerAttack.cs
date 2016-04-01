using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	private bool attacking = false;
	private float attackTimer = 0f;
	private float attackCD = 0.3f;

	public Collider2D attackTrigger;
	private Animator anime;

	void Awake() {
		anime = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update() {
		#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
			if(Input.GetKeyDown("a") && !attacking) {
				Attack();
			}
		#endif

		if(attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		//anime.SetBool ("Attacking", attacking);
	}

	public void Attack() {
		attacking = true;
		attackTimer = attackCD;
		attackTrigger.enabled = true;
	}
}

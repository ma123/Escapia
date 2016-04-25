using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour {
	public int enemyHP = 50;
	public float attackStrength = 20;

	private string currentLevel;
	private int levelIndex;
	private GameObject endLevelPanel;

	public GameObject[] hearths;
	private bool[] deadHearth = {true, true, true, true, true};
	private bool[] oneReduce = {true, true, true, true, true};

	private Animator anim;
	private BoxCollider2D enemyCollision;
	private Rigidbody2D enemyRigidbody;

	private bool walking = true;
	private bool attacking = false;
	private float attackTimer = 0f;
	private float attackCD = 1.0f;
	public Collider2D attackTrigger;
	public float waitAttack = 0.3f;
	private float lastTime = 0.0f;

	void Start () {
		anim = GetComponent<Animator>();
		enemyCollision = GetComponent<BoxCollider2D> ();
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		attackTrigger.enabled = false;
		currentLevel = SceneManager.GetActiveScene().name; 
		endLevelPanel = GameObject.Find ("ReactionFromEndPanel");
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 5; i++) {
			deadHearth [i] = hearths [i].GetComponent<LeviathanHearth> ().GetWalking();
			if (!deadHearth [i]) {
				if(oneReduce[i]) {
					enemyHP -= 10;
					waitAttack += 3.0f;
					oneReduce [i] = false;
				}
			}
		}

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
		health.GetComponent<HealthScript> ().Hit(attackStrength);
	}
	
	public void EnemyHit (int gunStrength) {
		enemyHP -= gunStrength;
		if(enemyHP <= 0) {
			anim.SetBool ("Death",true);
			walking = false;
			this.gameObject.tag = "Untagged";
			enemyRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			enemyCollision.isTrigger = true;

			UnlockLevels ();
			endLevelPanel.GetComponent<ReactionFromPanelScript> ().PausePanelReaction (3);
		}
	}

	protected void UnlockLevels (){
		for (int i = 1; i <= LevelSelectionScript.GetNumberOfLevels(); i++) {
			if (currentLevel == i.ToString ()) {
				levelIndex = (i + 1);
				PlayerPrefs.SetInt ("lvl" + levelIndex.ToString (), 1);
			}
		}
	}
}



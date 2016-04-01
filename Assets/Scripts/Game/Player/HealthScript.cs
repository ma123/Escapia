using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private static int health = 100;
	private static float initSize;
	private static bool isDead = false;
	public GameObject deadPanel;
	private static Transform transformHealth;
	
	// Use this for initialization
	void Start () {
		transformHealth = transform;
		initSize = transformHealth.localScale.x;  // zisti pociatocnu velkost health baru
		health = 100;
		RefreshHealthBar ();
	}
	
	public static void Hit(int damage) {
		if(isDead) {
			return;
		}
		
		health -= damage;
		
		if(health <= 0) {
			health = 0;
			isDead = true;
		}
		
		RefreshHealthBar ();
	}

	public static void AddHealth(int addedHealth) {

		health += addedHealth;
		if(health >= 100) {
			health = 100;
		}


		RefreshHealthBar ();
	}

	void OnGUI() {
		if (isDead) {
			Time.timeScale = 0; // pauznutie hry
			deadPanel.SetActive(true);
			isDead = false;
		} 
	}
	
    private static void RefreshHealthBar() {
		Vector3 scale = transformHealth.localScale;
		scale.x = (initSize / 100) * health;
		transformHealth.localScale = scale;
	}
}

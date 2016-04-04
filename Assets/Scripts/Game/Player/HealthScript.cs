using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private float health = 100f;
	public GameObject deadPanel;
	public GameObject healthBar;
	
	// Use this for initialization
	void Start () {
		health = 100f;
		RefreshHealthBar ();
	}
	
	public void Hit(float damage) {
		health -= damage;
		
		if(health <= 0f) {
			health = 0f;
			Time.timeScale = 0; // pauznutie hry
			deadPanel.SetActive(true);
		}
		
		RefreshHealthBar ();
	}

	public void AddHealth(float addedHealth) {
		health += addedHealth;
		if(health >= 100f) {
			health = 100f;
		}

		RefreshHealthBar ();
	}
	
    private void RefreshHealthBar() {
		Scrollbar healthScroll = healthBar.GetComponent<Scrollbar> ();
		healthScroll.size = health / 100f;
	}
}
	

	

	
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private float health = 100f;
	private GameObject endLevelPanel;
	public GameObject healthBar;
	
	// Use this for initialization
	void Start () {
		endLevelPanel = GameObject.Find ("ReactionFromEndPanel");
		health = 100f;
		RefreshHealthBar ();
	}
	
	public void Hit(float damage) {
		health -= damage;
		
		if(health <= 0f) {
			health = 0f;
			endLevelPanel.GetComponent<ReactionFromPanelScript> ().PausePanelReaction (2);
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
	

	

	
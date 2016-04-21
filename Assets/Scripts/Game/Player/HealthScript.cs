using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {
	private float health = 100f;
	private GameObject endLevelPanel;
	public GameObject healthBar;
	private GameObject player;

	private bool particleEnd = false;
	private bool isParticle = true;
	public GameObject deadParticles;
	private GameObject soundsAndMusic;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		soundsAndMusic = GameObject.Find ("SoundsAndMusic");
		endLevelPanel = GameObject.Find ("ReactionFromEndPanel");
		health = 100f;
		RefreshHealthBar ();
	}

	void Update() {
		if(particleEnd) {
			endLevelPanel.GetComponent<ReactionFromPanelScript>().PausePanelReaction(2); // parameter 2 pre dead stav
			particleEnd = false;
		}
	}

	public void DestroyPlayer() {
		if(isParticle) {
			StartCoroutine(WaitParticle());
			soundsAndMusic.GetComponent<SoundsAndMusicScript> ().LooseSound (transform);

			player.GetComponent<SpriteRenderer>().enabled = false;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
			Instantiate(deadParticles, player.transform.position, player.transform.rotation);
			isParticle = false;
		}
	}

	// prejdu 2 sekundy nasledne sa firstMeasure zmeni na true
	IEnumerator WaitParticle() { 
		yield return new WaitForSeconds(1f);
		particleEnd = true;
	}
	
	public void Hit(float damage) {
		health -= damage;
		soundsAndMusic.GetComponent<SoundsAndMusicScript> ().HurtSound (transform);
		
		if(health <= 0f) {
			health = 0f;
			DestroyPlayer ();
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
	

	

	
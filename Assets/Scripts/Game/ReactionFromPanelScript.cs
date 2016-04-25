using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using System.Collections;
using System;

public class ReactionFromPanelScript : MonoBehaviour {
	public GameObject endLevelPanel;
	private GameObject soundsAndMusic;
	public GameObject statsPanel;
	public GameObject controlPanel;

	void Start() {
		Time.timeScale = 1; // spustenie hry
		soundsAndMusic = GameObject.FindGameObjectWithTag ("SoundsAndMusic");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			PausePanelReaction(1); // parameter pre pauzu
		}
	}

	public void PausePanelReaction(int reaction) {
		Time.timeScale = 0; // pauznutie hry
		statsPanel.SetActive(false);
		controlPanel.SetActive (false);
		endLevelPanel.SetActive(true);

		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript>().GetMusicBackgroundObject().Pause(); // pauznutie background hudby
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}

		GameObject btnInteractable = GameObject.Find("NextLevel");
		GameObject btnInteractableBack = GameObject.Find("BackToGame");

		switch(reaction) {
		case 1:    //pause
			btnInteractable.GetComponent<Button>().interactable = false;
			break;

		case 2:   //dead
			btnInteractable.GetComponent<Button> ().interactable = false;
			btnInteractableBack.GetComponent<Button> ().interactable = false;
			break;
		case 3:   //winn
			btnInteractableBack.GetComponent<Button> ().interactable = false;
			break;
		default:
			Debug.Log ("Nieco sa zmrvilo");
			break;
		}
	}

	public void NextLevel() {
		string currentLevel = SceneManager.GetActiveScene().name; 
		int levelNumber = int.Parse (currentLevel.ToString()); // ziskam cislo levela

		if (levelNumber == LevelSelectionScript.GetNumberOfLevels()) {  // ak sme v poslednom levele
				SceneManager.LoadScene("LevelSelector");
		} else {
			SceneManager.LoadScene((levelNumber+1),LoadSceneMode.Single);
		}
	}
	
	public void RestartLevel() {
		string sceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
	}

	public void BackMenu() {
		print ("backLevelSelector");
		SceneManager.LoadScene("LevelSelector");
	}

	public void BackToGame() {
		Time.timeScale = 1; // spustenie hry
		statsPanel.SetActive(true);
		controlPanel.SetActive (true);
		endLevelPanel.SetActive(false);
		try {
			soundsAndMusic.GetComponent<SoundsAndMusicScript> ().GetMusicBackgroundObject().Play (); // znovu spustenie hudby pozadia
		} catch(Exception e) {
			Debug.Log ("Sound exception in panel" + e);
		}
	}
}
	

	

	


	

	
	
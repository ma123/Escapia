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
		print ("nextLevel");
		/*string currentLevel = SceneManager.GetActiveScene().name; // ziskam nazov levelu
		int worldNumber = int.Parse (currentLevel[5].ToString()); // ziskam cislo sveta
		string[] splitString = currentLevel.Split ('.');
		int levelNumber = int.Parse (splitString [1]); // ziskam cislo levelu

		if (levelNumber == LockLevelScript.levels) {  // ak sme v poslednom levele 
			if (worldNumber == LockLevelScript.worlds) { // ak sme v poslednom svete 
				//Application.LoadLevel ("MainMenuScene");  // tak sa dostaneme do hlavneho menu
				SceneManager.LoadScene("MainMenuScene");
			} else {
				SceneManager.LoadScene("Level" + (worldNumber + 1) + "." + "1");
				//Application.LoadLevel ("Level" + (worldNumber + 1) + "." + "1");  // tak otvorime level 1 v dalsom svete
			}
		} else {
			SceneManager.LoadScene(splitString[0]+ "." + (levelNumber+1),LoadSceneMode.Single);
		}*/
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
	

	

	


	

	
	
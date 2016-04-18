using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	private static int numberOfLevels = 10;
	public GameObject levelLoadingPanel;
	private int loadProgress;

	void Start() {
		for(int j = 2; j <= numberOfLevels; j++){ // podla poctu levelo
			if((PlayerPrefs.GetInt("level"+j.ToString(), 0))==1){
				GameObject.Find("Lvl"+j+"Lock").SetActive(false); // vypnutie tlacitka zo zamkom nad skutocnym tlacitkom
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenuScene");
		}
	}

	public void OnClickedLevel(string level) {
		StartCoroutine (DisplayLevelLoadingScreen(level));
	}

	public void BackToMenu() {
		SceneManager.LoadScene("MainMenuScene");
	}

	// asynchronne nacitanie sceny
	IEnumerator DisplayLevelLoadingScreen(string worldLevel) {
		AsyncOperation async = 	SceneManager.LoadSceneAsync("Level" + worldLevel);//Application.LoadLevelAsync ("Level"+worldLevel);
		levelLoadingPanel.SetActive (true);
		Scrollbar progressBar = levelLoadingPanel.GetComponentInChildren<Scrollbar> ();

		while(!async.isDone) {
			loadProgress = (int)(async.progress * 100) + 10;
			progressBar.size = loadProgress / 100f;
			yield return null;
		}
	}

	public static int GetNumberOfLevels() {
		return numberOfLevels;
	}
}
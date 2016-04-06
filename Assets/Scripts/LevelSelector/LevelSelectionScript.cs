using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	private int openedLevel = 1;	
	private int numberOfLevels = 6;
	private GameObject gameObject;

	public GameObject levelLoadingPanel;
	private int loadProgress;

	void Start() {
		openedLevel = PlayerPrefs.GetInt ("openedLevel", 1);

		// vypnutie interakcie levelov ktore nie su pristupne
		for(int i = openedLevel+1; i <= numberOfLevels; i++) {
			gameObject = GameObject.Find("Lvl"+i+"Btn");
			gameObject.GetComponent<Button>().interactable = false;
		}

		//PlayerPrefs.DeleteAll ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenuScene");
		}
	}

	public void OnClickedLevel(string level) {
		//PlayerPrefs.SetInt("currentLevel", level);
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
}
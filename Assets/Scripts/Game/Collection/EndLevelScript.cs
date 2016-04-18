using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class EndLevelScript : MonoBehaviour {
	private string currentLevel;
	private int levelIndex;
	private GameObject endLevelPanel;

	void Start() {
		currentLevel = SceneManager.GetActiveScene().name; 
		endLevelPanel = GameObject.Find ("ReactionFromEndPanel");
	}

	public void EndLevelReact () {
		UnlockLevels ();
		endLevelPanel.GetComponent<ReactionFromPanelScript> ().PausePanelReaction (3);
	}

	protected void UnlockLevels (){
		for (int i = 1; i <= LevelSelectionScript.GetNumberOfLevels(); i++) {
			if (currentLevel == "Level" + i.ToString ()) {
				levelIndex = (i + 1);
				PlayerPrefs.SetInt ("level" + levelIndex.ToString (), 1);
			}
		}
	}
}
	
	
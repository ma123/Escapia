using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {
	private int openedLevel = 0;
	private int currentLevel = 0;
	private GameObject endLevelPanel;

	void Start() {
		endLevelPanel = GameObject.Find ("ReactionFromEndPanel");
	}

	public void EndLevelReact () {
		print ("end level");
		openedLevel = PlayerPrefs.GetInt ("openedLevel", 1);
		currentLevel = PlayerPrefs.GetInt ("currentLevel");

		if(currentLevel == openedLevel) {
			openedLevel++;
			PlayerPrefs.SetInt("openedLevel", openedLevel);
			openedLevel = PlayerPrefs.GetInt ("openedLevel");
		}

		endLevelPanel.GetComponent<ReactionFromPanelScript> ().PausePanelReaction (3);
	}
}

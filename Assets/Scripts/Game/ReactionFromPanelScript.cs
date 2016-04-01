using UnityEngine;
using System.Collections;

public class ReactionFromPanelScript : MonoBehaviour {
	public void NextLevel() {
		print ("nextLevel");
	}
	
	public void RestartLevel() {
		print ("restartLevel");
		Application.LoadLevel (Application.loadedLevel);
	}

	public void BackMenu() {
		print ("backLevelSelector");
		Application.LoadLevel ("LevelSelector");
	}
}
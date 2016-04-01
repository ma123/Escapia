using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlLevelSelectorScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenuScene");
		}
	}
}

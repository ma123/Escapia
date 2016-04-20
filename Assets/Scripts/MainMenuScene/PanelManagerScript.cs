using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PanelManagerScript : MonoBehaviour {
	public GameObject[] panels;
	private int currentPanelIndex;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		currentPanelIndex = 0;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			ChangePanel(1);
		}
	}

	public void ChangePanel(int panelIndex) {
		panels [currentPanelIndex].SetActive (false);
		currentPanelIndex = panelIndex;
		panels [currentPanelIndex].SetActive (true);
	}


	public void OpenLevelSelector() {
		SceneManager.LoadScene("LevelSelector");
	}

	public void ClickedSettings() {
		ChangePanel(2);
	}

	public void OpenFacebookPage() {
		Application.OpenURL("https://www.facebook.com/atonomgames/?ref=aymt_homepage_panel");
	}

	public void OpenRatingPlayPage() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=sk.ag.escapia");
	}

	public void OpenGPlusPage() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=sk.ag.drawingroad");
	}

	public void OpenMainPage() {
		Application.OpenURL("http://www.escapia.tk/");
	}

	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}
}
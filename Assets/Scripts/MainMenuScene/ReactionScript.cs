using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReactionScript : MonoBehaviour {
	public GameObject loadingLevelPanel;

	public void ClickedLevelSelector() {
		print ("clicked load LevelSelector");
		StartCoroutine (LoadLevel());
	}
	
	public void ClickedShop() {
		print ("clicked shop");
		SceneManager.LoadScene ("Shop");
	}
		
	public void ClickedExit() {
		print ("clicked exit");
		Application.Quit ();
	}

	IEnumerator LoadLevel() {
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync ("LevelSelector");
		
		loadingLevelPanel.SetActive (true);
		Text progressText = loadingLevelPanel.GetComponentInChildren<Text>();
		
		while(!asyncOperation.isDone) {
			print (asyncOperation.progress);
			progressText.text = (asyncOperation.progress * 100).ToString("N") + "%";
			yield return null;
		}
	}
}

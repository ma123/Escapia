using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsSoundsAndMusic : MonoBehaviour {
	public Toggle soundToggle;
	public Toggle musicToggle;
	private int soundInt = 0;
	private int musicInt = 0;

	// Use this for initialization
	void Start () {
		soundInt = PlayerPrefs.GetInt("sound",1);
		musicInt = PlayerPrefs.GetInt("music",1);

		if (soundInt == 0) {
			soundToggle.isOn = false;
		} else {
			soundToggle.isOn = true;
		}

		if (musicInt == 0) {
			musicToggle.isOn = false;
		} else {
			musicToggle.isOn = true;
		}
	}

	public void ClickSoundEnabled() {
		if (soundToggle.isOn) {
			PlayerPrefs.SetInt ("sound", 1);
		} else {
			PlayerPrefs.SetInt ("sound", 0);
		}
	}

	public void ClickMusicEnabled() {
		if (musicToggle.isOn) {
			PlayerPrefs.SetInt ("music", 1);
		} else {
			PlayerPrefs.SetInt ("music", 0);
		}
	}
}

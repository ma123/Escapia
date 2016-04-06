using UnityEngine;
using System;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	// sound effect

//	public AudioClip noInkClips;
	// music
	public AudioClip bgIntro01;
	public AudioClip bgLoop01;
	public AudioClip bgIntro02;
    public AudioClip bgLoop02;
	public AudioClip bgIntro03;
	public AudioClip bgLoop03;

	private AudioSource musicBackground;

	private int soundEnabled = 0;
	private int musicEnabled = 0;
	
	void Start() {
		soundEnabled = PlayerPrefs.GetInt("sound",1);
		musicEnabled = PlayerPrefs.GetInt("music",1);

		if (musicEnabled == 1) {
			musicBackground = this.GetComponent<AudioSource> ();
			StartCoroutine(PlayBackgroundMusic());
		}
	}

	IEnumerator PlayBackgroundMusic() {
		int randomNumber = UnityEngine.Random.Range(1, 4);
		print (randomNumber);
		switch(randomNumber) {
		case 1:
			print ("bg 01");
					musicBackground.clip = bgIntro01;  // priradi intro melodiu  
					musicBackground.Play();  
					yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
					musicBackground.clip = bgLoop01; // priradi loop melodiu
					break;
			case 2:
			print ("bg 02");
					musicBackground.clip = bgIntro02;  // priradi intro melodiu  
					musicBackground.Play();  
					yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
					musicBackground.clip = bgLoop02; // priradi loop melodiu
					break;
			case 3:
			print ("bg 03");
					musicBackground.clip = bgIntro03;  // priradi intro melodiu  
					musicBackground.Play();  
					yield return new WaitForSeconds(musicBackground.clip.length);  // ked zisti ze skoncilo intro 
					musicBackground.clip = bgLoop03; // priradi loop melodiu
					break;
		}
		musicBackground.Play();
	}

	public AudioSource GetMusicBackgroundObject() {
		return musicBackground;
	}

	/*public void PickupInkAudio(Transform transPos) {
		PhoneVibrate ();

		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (inkClips, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}*/
}

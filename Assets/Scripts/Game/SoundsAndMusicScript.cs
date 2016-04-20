using UnityEngine;
using System;
using System.Collections;

public class SoundsAndMusicScript : MonoBehaviour {
	// music
	public AudioClip bgIntro01;
	public AudioClip bgLoop01;
	public AudioClip bgIntro02;
    public AudioClip bgLoop02;
	public AudioClip bgIntro03;
	public AudioClip bgLoop03;
	// sfx sounds
	public AudioClip lifeClip;
	public AudioClip boneClip;
	public AudioClip winnClip;
	public AudioClip loseClip;
	public AudioClip hurtClip;
	public AudioClip attackClip;

	private AudioSource musicBackground;
	private float sfxVolume = 1.0f;
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

	public void PickupLife(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (lifeClip, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}

	public void PickupBone(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (boneClip, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}

	public void LooseSound(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (loseClip, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}

	public void WinnSound(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (winnClip, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}

	public void HurtSound(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (hurtClip, transPos.position);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}

	public void AttackSound(Transform transPos) {
		if (soundEnabled == 1) {
			try {
				AudioSource.PlayClipAtPoint (attackClip, transPos.position, sfxVolume);
			}
			catch (Exception e) {
				Debug.Log ("Sound problem " + e);
			}  
		}
	}
}

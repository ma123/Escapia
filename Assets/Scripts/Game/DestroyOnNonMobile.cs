using UnityEngine;
using System.Collections;

public class DestroyOnNonMobile : MonoBehaviour {

	// Use this for initialization
	#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
	void Start () {
		   Destroy (this.gameObject);
	}
	#endif
}

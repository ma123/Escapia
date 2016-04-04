using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	public void CoinReact () {
		print ("destroy object coin");
		ScoreScript.AddScore(1);
		Destroy (gameObject);
	}
}

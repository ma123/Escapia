using UnityEngine;
using System.Collections;

public class DestroyerScript: MonoBehaviour {
	void Start () 
	{
		Destroy(gameObject, 0.3f);
	}
}

using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public Transform observingObject;
	public bool withOffset;
	public int offset;
	
	void Update()
	{
		if (observingObject == null)
			return;
		
		Vector3 pos = transform.position;
		Vector3 newPos = observingObject.position;
		
		if (withOffset) {
			newPos.x += offset;
			newPos.y += offset;
		}

		newPos.z = pos.z;
		
		transform.position = Vector3.Lerp(transform.position, newPos, 1f);

		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel("LevelSelector"); 
		}
	}
}

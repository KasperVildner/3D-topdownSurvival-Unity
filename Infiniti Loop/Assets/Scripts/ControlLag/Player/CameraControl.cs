using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public float cameraHeight = 10.0f;
	public float cameraWidth = -6.0f;

	void Update () {

		//Make Camera follow player postition
		Vector3 pos = player.transform.position;
		pos.y += cameraHeight;
		pos.z += cameraWidth;
		transform.position = pos;
	}
}

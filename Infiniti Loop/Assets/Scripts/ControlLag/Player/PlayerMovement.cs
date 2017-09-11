using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 5;

	Camera viewCamera;
	PlayerController controller;

	void Start () {
		controller = GetComponent<PlayerController> ();
		viewCamera = Camera.main;
	}

	void Update () {
		//Control the movement of the player (Movement Input)
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move (moveVelocity);

		//Camera ray tracking for rotation (Look Input)
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast (ray, out rayDistance))
		{
			Vector3 point = ray.GetPoint (rayDistance);
			//Debug.DrawLine (ray.origin, point, Color.red); //Draw's a line from camera to plane
			controller.LookAt(point);
		}

		//Weapon input
	}
}

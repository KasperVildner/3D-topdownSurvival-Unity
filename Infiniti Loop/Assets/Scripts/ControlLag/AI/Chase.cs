using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Transform player;
	public float movementSpeed;
	public int willChaseDistance;
	public int fieldOfView;
	public int attackDistance;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate to face the player position when in range
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < willChaseDistance && angle < fieldOfView) 
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
		
			//move in the direction of the player position when in range
			if (direction.magnitude > attackDistance) 
			{
				this.transform.Translate (0, 0, movementSpeed);
			}
		}
	}
}

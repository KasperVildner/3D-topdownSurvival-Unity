using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowProjectile : MonoBehaviour {

	float speed = 10;

	public void setSpeed(float newSpeed)
	{
		speed = newSpeed;
	}

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);


		if (!this.GetComponent<Renderer> ().isVisible) {
			print ("Shot deleted!!!");
			gameObject.SetActive (false);
		}

		//Debug.Log("Visible " + GetComponent<Renderer>().isVisible);

	}


}

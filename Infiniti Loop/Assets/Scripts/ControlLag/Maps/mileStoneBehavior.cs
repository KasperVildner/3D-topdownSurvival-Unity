using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mileStoneBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Trees") || other.gameObject.CompareTag ("Minerals") || other.gameObject.CompareTag ("Enemy")) {
			Destroy (other.gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

	bool mouseDown = false;
	float timer;
	float waitTime;
	bool isWeaponEquipt = true;


	// Use this for initialization
	void Start () {
		timer = waitTime;
		waitTime = 1f;
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = false;

	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;

			//Debug.Log ("Tryk");
		} else 
		{
			mouseDown = false;
		}

		if (Input.GetMouseButtonUp (0))  
		{
			mouseDown = false;
			Disable ();
		}

	}

	public static class WaitFor
	{
		public static IEnumerator Frames(int frameCount)
		{
			if (frameCount <= 0) 
			{
				Debug.Log (frameCount + "cannot wait for less that 1 frame");
			}
			while (frameCount > 0) 
			{
				frameCount--;
				yield return null;
			}
		}
	}

	public IEnumerator CoroutineAction()
	{
		yield return StartCoroutine(WaitFor.Frames (1));
	}

	void FixedUpdate()
	{
		UseAxe ();
	}

	public void setIsWeaponEquipt(bool setBool)
	{
		isWeaponEquipt = setBool;
	}
	public void UseAxe(/*bool isWeaponEquipt*/)
	{

		if (mouseDown && isWeaponEquipt) 
		{
			Enable ();
			CoroutineAction ();
			//Disable ();
			if (timer < 0) {
				timer = waitTime;
				Debug.Log ("skade");
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Trees")
		{
			other.gameObject.GetComponent<SpawnInstance> ().DealDamage (10);
			Debug.Log ("Hit at tree");
		}
	}

	void Disable()
	{
		this.gameObject.GetComponent<BoxCollider> ().enabled = false;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = false;
	}

	void Enable()
	{
		this.gameObject.GetComponent<BoxCollider> ().enabled = true;
		this.gameObject.GetComponent<MeshRenderer> ().enabled = true;
	}


}

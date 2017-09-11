 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	public Transform shotFrom;
	public BowProjectile bowPro;
	public float msBetweenShots = 100;
	public float shotSpeed = 35;

	float nextShotTime;
	WeaponController weaponController;

	void Start()
	{
		weaponController = GetComponent<WeaponController> ();
	}

	void Update()
	{
		MouseShot ();
	}
	public void Shoot()
	{	
		if (Time.time > nextShotTime) 
		{
			nextShotTime = Time.time + msBetweenShots / 1000;

			GameObject obj = ObjectPoolerScript.current.GetpooledObject ();

			obj.transform.position = shotFrom.position;
			obj.transform.rotation = shotFrom.rotation;
			obj.SetActive (true);
			//BowProjectile newProjectile = Instantiate (bowPro, shotFrom.position, shotFrom.rotation) as BowProjectile;
			//obj.setSpeed (shotSpeed);
		}

	}

	//Weapon input
	void MouseShot()
	{
		
		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log ("Shot fired");
			Shoot();
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInstance : MonoBehaviour {

	private double health = 30;

	//Set object health
	public void SetHealth(double health)
	{
		this.health = health;
	}

	//Take damage from player and substract it from object health
	public void DealDamage(double damage)
	{
		health -= damage;
		if (health < 0) 
		{
			Die ();
		}
	}

	//Destroy given object
	void Die ()
	{
		Destroy (this.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterHealth : MonoBehaviour {

	public double CurrentHealth { get; set; }
	public double MaxHealth { get; set; }

	public Slider healthBar;

	// Use this for initialization
	void Start () {
		MaxHealth = 20;
		//Resets health to full on load
		CurrentHealth = MaxHealth;

		healthBar.value = CalculateHealthToProcent ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X))
			DealDamage (2);
		
	}

	void DealDamage(double damageValue)
	{
		//Deal the damage value to the current damage
		CurrentHealth -= damageValue;
		//Set the healthbar
		healthBar.value = CalculateHealthToProcent();
		//Die if character is out of health
		if (CurrentHealth <= 0)
			die ();
	}

	float CalculateHealthToProcent()
	{
		float newHealth = Convert.ToSingle (CurrentHealth / MaxHealth);
		return newHealth;
	}

	void die()
	{
		CurrentHealth = 0;
		Debug.Log ("Your died");
	}
}

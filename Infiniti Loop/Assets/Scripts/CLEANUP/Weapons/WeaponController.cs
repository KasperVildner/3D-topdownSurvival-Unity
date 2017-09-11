using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Weapon WBow;
	public Weapon WSword;
	public Weapon WAxe;
	public Weapon WPickAxe;

	public Axe axe;

	public Transform weaponHold;
	public Weapon startingWeapon = null;
	Weapon equippedWeapon;

	void Start()
	{
		//If there are no starting weapon, give one
		if (startingWeapon != null) 
		{
			EquipWeapon (startingWeapon);
		}
	}

	void FixedUpdate()
	{
		SwiftWeapon ();
	}

	public void EquipWeapon(Weapon weaponToEquip)
	{
		//Check if there is already a eqquiped weapon if there is, destroy it
		if (equippedWeapon != null) 
		{
			Destroy (equippedWeapon.gameObject);
		}
		//Equip new weapon at WeaponHold objects postition and rotation
		equippedWeapon = Instantiate (weaponToEquip, weaponHold.position,weaponHold.rotation) as Weapon;
		//Make weapon a child of the weaponhold
		equippedWeapon.transform.parent = weaponHold;
	}

	public void SwiftWeapon()
	{
		bool checkPressed = false;
		//Equip weapon slot 1
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			axe.setIsWeaponEquipt(false);
			EquipWeapon(WSword);
			Debug.Log ("Sword is equipped");
			checkPressed = !checkPressed;
		}

		//Equip weapon slot 1
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			axe.setIsWeaponEquipt(false);
			EquipWeapon(WBow);
			Debug.Log ("Bow is equipped");
			checkPressed = !checkPressed;
		}

		//Equip weapon slot 1
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			axe.setIsWeaponEquipt(true);
			EquipWeapon(WAxe);
			Debug.Log ("Axe is equipped");
			checkPressed = !checkPressed;
		}

		//Equip weapon slot 1
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			axe.setIsWeaponEquipt(false);
			EquipWeapon(WPickAxe);
			Debug.Log ("Pickaxe is equipped");
			checkPressed = !checkPressed;
		}

	}
}

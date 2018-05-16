using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedItem : MonoBehaviour {

    public Items items;

    public string weaponName;
    public int weaponDamage;
    public bool weaponEquipped = false;
    public int eWeaponTier = 0;

	void Start () {

	}

    public void UpdateWeapon() {
        if (weaponEquipped == true) {
            items.SetWeapon(eWeaponTier);
            weaponName = items.itemName;
            weaponDamage = items.damage;
        }
    }
	
	void Update () {
		
	}
}

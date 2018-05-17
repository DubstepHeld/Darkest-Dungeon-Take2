using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedItem : MonoBehaviour {
    //angelegte waffe, wird jedem player zugewiesen

    public Items items;
    public TransferVars transfer;

    [Header("Variablen")]
    public string weaponName;
    public int weaponDamage;
    public int eWeaponTier = 0;
    public int index;

	void Start () {
        index = this.gameObject.GetComponentInParent<Character>().position; //index entspricht der position des spielers
        transfer = GameObject.FindGameObjectWithTag("Transfer").GetComponent<TransferVars>();
        UpdateWeapon();
	}

    public void UpdateWeapon() {
        //übernehme werte von transferObjekt
        weaponName = transfer.weaponName[index];
        weaponDamage = transfer.weaponDamage[index];
        eWeaponTier = transfer.weaponTier[index];
    }
}

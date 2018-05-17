using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetItemText : MonoBehaviour {

    public TransferVars transfer;
    public Items items;

    public Text[] weaponText;
    public Text[] weaponTier;
    public Text[] weaponDamage;

    public int tier;

    // Use this for initialization
    void Start () {
        transfer = GameObject.FindGameObjectWithTag("Transfer").GetComponent<TransferVars>();
        UpdateText();
    }

	// Update is called once per frame
	public void UpdateText() {
        for(int i = 0; i < 4; i++) {
            weaponText[i].text = transfer.weaponName[i];
            weaponTier[i].text = transfer.weaponTier[i].ToString();
            weaponDamage[i].text = transfer.weaponDamage[i].ToString();
        }
    }

    public void SetTier(int tier) {
        this.tier = tier;
    }

    public void SwitchWeapon(int characterIndex) {
        items.SetWeapon(tier);
        transfer.weaponName[characterIndex] = items.itemName;
        transfer.weaponTier[characterIndex] = tier;
        transfer.weaponDamage[characterIndex] = items.damage;
        UpdateText();
    }
}

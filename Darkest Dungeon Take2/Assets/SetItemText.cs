using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetItemText : MonoBehaviour {

    public WeaponSetter wSetter;

    public Text weaponText0;
    public Text weaponStats0_1;
    public Text weaponStats0_2;
    public Text weaponText1;
    public Text weaponStats1_1;
    public Text weaponStats1_2;
    public Text weaponText2;
    public Text weaponStats2_1;
    public Text weaponStats2_2;
    public Text weaponText3;
    public Text weaponStats3_1;
    public Text weaponStats3_2;

    // Use this for initialization
    void Start () {
        //UpdateText();
    }
	
	// Update is called once per frame
	public void UpdateText() {
        //nicht schön, funktioniert aber...
        weaponText0.text = wSetter.carriedItem[0].weaponName;
        weaponText1.text = wSetter.carriedItem[1].weaponName;
        weaponText2.text = wSetter.carriedItem[2].weaponName;
        weaponText3.text = wSetter.carriedItem[3].weaponName;

        weaponStats0_1.text = "Tier: " + wSetter.carriedItem[0].eWeaponTier.ToString();
        weaponStats1_1.text = "Tier: " + wSetter.carriedItem[1].eWeaponTier.ToString();
        weaponStats2_1.text = "Tier: " + wSetter.carriedItem[2].eWeaponTier.ToString();
        weaponStats3_1.text = "Tier: " + wSetter.carriedItem[3].eWeaponTier.ToString();

        weaponStats0_2.text = "Damage: " + wSetter.carriedItem[0].weaponDamage.ToString();
        weaponStats1_2.text = "Damage: " + wSetter.carriedItem[1].weaponDamage.ToString();
        weaponStats2_2.text = "Damage: " + wSetter.carriedItem[2].weaponDamage.ToString();
        weaponStats3_2.text = "Damage: " + wSetter.carriedItem[3].weaponDamage.ToString();
    }
}

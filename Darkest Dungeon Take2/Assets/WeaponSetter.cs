using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour {

    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];
    public CarriedItem[] carriedItem = new CarriedItem[4];
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public Items items;
    public SetItemText setItemText;

    public int tier;

	// Use this for initialization
	void Start () {

        player[0] = GameObject.Find("Player");
        player[1] = GameObject.Find("Player (1)");
        player[2] = GameObject.Find("Player (2)");
        player[3] = GameObject.Find("Player (3)");

        character[0] = player[0].GetComponent<Character>();
        character[1] = player[1].GetComponent<Character>();
        character[2] = player[2].GetComponent<Character>();
        character[3] = player[3].GetComponent<Character>();

        carriedItem[0] = player[0].GetComponent<CarriedItem>();
        carriedItem[1] = player[1].GetComponent<CarriedItem>();
        carriedItem[2] = player[2].GetComponent<CarriedItem>();
        carriedItem[3] = player[3].GetComponent<CarriedItem>();

        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        items = playerManager.GetComponent<Items>();
        
        playerManager.gameObject.SetActive(false);
        enemyManager.gameObject.SetActive(false);
    }

    public void SetTier(int tier) {
        this.tier = tier;
    }
	
	public void SwitchWeapon(int characterIndex) {
        items.SetWeapon(tier);
        carriedItem[characterIndex].weaponName = items.itemName;
        carriedItem[characterIndex].weaponDamage = items.damage;
        carriedItem[characterIndex].eWeaponTier = tier;
        setItemText.UpdateText();
    }
}

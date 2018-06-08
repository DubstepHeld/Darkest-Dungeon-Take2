using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour {

	//Made by Samuel

	[Header("Script stuff")]
	int prevPlayerIndex;
    public Races races;
    public PlayerManager playerManager;
    public SpriteRenderer spriteRenderer;
    public GameObject border;
	public GameObject healthbar;
    
    [Header("Character Stats")]
    public int      playerIndex = 5;                 //0=ass, 1=dd, 2=heal, 3=sup, 4=tank, 5=empty
    public int      health =     100;
    public int      damage =     0;
    public int      armor =      0;
    public float    hitChance =  0;              //0-1
    public int      dodge =      0;
    public float    blightRes =  0;              //0-1
    public float    stunRes =    0;              //0-1
    public float    bleedRes =   0;              //0-1
    public int      initiative = 0;
    public int      position;
    public int[] range = new int[4];
	public int maxHealth = 1;


	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.GetSiblingIndex();
        UpdateStats();
	}

	void Update () {
		healthbar.transform.localScale = new Vector3 (10 * health / maxHealth, 1, 1);

		if (Input.GetKeyDown("r") || playerIndex != prevPlayerIndex) {
            //wenn character gewechselt wird, aktualisiert das skript die Rasse
            UpdateStats();
        }
        if(health <= 0) {
            spriteRenderer.sprite = races.deadSprites[playerIndex];
			healthbar.SetActive (false);
        }
	}
    
    public void UpdateStats() {
        //Rassenwechsel/neue werte
        //Races nimmt diese rasse an
        //werte können dann von races übernommen werden
        races.SetClass(playerIndex);  //inizialisiere Rassenwechsel
        health = races.health;
        damage = races.damage;
        hitChance = races.hitChance;
        dodge = races.dodge;
        blightRes = races.blightRes;
        stunRes = races.stunRes;
        bleedRes = races.bleedRes;
        initiative = races.initiative;

		maxHealth = races.health;
        //range noch nicht verwendet
        for (int i = 0; i < 4; i++) {
            range[i] = races.range[i];
        }
        spriteRenderer.sprite = races.idleSprites[playerIndex];
        playerManager.image.sprite = races.idleSprites[playerIndex];
		prevPlayerIndex = playerIndex;
    }

    void OnMouseDown() {    //wenn draufgeklickt wird
        playerManager.selected = position;
        playerManager.image.sprite = races.idleSprites[playerIndex];
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour {

	//Made by Samuel

    //public string className = "empty";
	public int enemyIndex = 5;  //0=ass, 1=dd, 2=heal, 3=sup, 4=tank
	int prevEnemyIndex;
    public Races races;
    public int position;
    public EnemyManager enemyManager;

    public SpriteRenderer spriteRenderer;

    public GameObject border;

    public int      health = 100;
    public int      damage = 0;
    public float    hitChance = 0;
    public int      dodge = 0;
    public float    blightRes = 0;
    public float    stunRes = 0;
    public float    bleedRes = 0;
    public int      initiative = 0;
	public int maxHealth = 1;

    //bool XPgained = false;

    public GameObject weapon;
    public GameObject armor;
	public GameObject healthbar;

    public PopUpThings popUpThings;
    public DungeonManager dungeonManager;

    // Use this for initialization
    void Start () {
		//enemyIndex = Random.Range (0, 5);
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.GetSiblingIndex();
        UpdateStats();
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.transform.localScale = new Vector3 (10 * health / maxHealth, 1, 1);

		if (Input.GetKeyDown("r") || enemyIndex != prevEnemyIndex) {
            UpdateStats();
        }
        if (health <= 0) {
            spriteRenderer.sprite = races.deadSprites[enemyIndex];
			healthbar.SetActive (false);
            /*
            if (!XPgained) {
                popUpThings.GainXP(dungeonManager.calcXP());
                XPgained = true;
            }
            */
        }
        //else XPgained = false;
    }

    public void UpdateStats() {
		races.SetClass(enemyIndex);

        health = races.health;
        damage = races.damage;
        hitChance = races.hitChance;
        dodge = races.dodge;
        blightRes = races.blightRes;
        stunRes = races.stunRes;
        bleedRes = races.bleedRes;
        initiative = races.initiative;

		maxHealth = races.health;

        spriteRenderer.sprite = races.idleSprites[enemyIndex];

		prevEnemyIndex = enemyIndex;
    }

    void OnMouseDown() {
        enemyManager.selectedEnemy = position;
    }
}

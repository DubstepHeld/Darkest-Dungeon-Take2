﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {

    public FightManager fightManager;

    [Header("Player Level")]
    public int expLevel;
    public int exp;
    public int startExp = 100;
    public int nextExp;

    [Header("Dungeon Level")]
    public int dungeonLevel = 0;
    public int startGainedXP = 10;
    public float dLevelMulti = 1.5f;

	// Use this for initialization
	void Start () {
        NewExp();
        dungeonLevel = fightManager.wave;
	}
	
	// Update is called once per frame
	void Update () {
        dungeonLevel = fightManager.wave;
        if (exp >= nextExp) {
            expLevel++;
            exp = exp - nextExp;
            NewExp();
        }
	}

    public void NewExp() {
        nextExp = Mathf.RoundToInt(startExp * Mathf.Pow(1.2f, expLevel));
    }

    public int calcXP() {
        return (Mathf.RoundToInt((startGainedXP + Random.Range(-dungeonLevel, dungeonLevel)) * Mathf.Pow(1.1f, dLevelMulti)));
    }
}

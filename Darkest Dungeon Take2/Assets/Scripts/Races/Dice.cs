﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dice : MonoBehaviour {

	//Made by Samuel

	public int RollDice(int max) {
        int value = Random.Range(0, max + 1);       //+1 weil min(inclusive) und max(exclusive)
        return value;
    }

    public int RollDice(int min, int max) {
        int value = Random.Range(min, max + 1);
        return value;
    }
}

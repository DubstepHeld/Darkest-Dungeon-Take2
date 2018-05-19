using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Support : MonoBehaviour {

	public Skilltree skills;
    public Dice dice;

    public string   className;
    public int      health;
    public int      damage;
    public float    hitChance;
    public int      dodge;
    public float    blightRes;
    public float    stunRes;
    public float    bleedRes;
    public int      initiative;
    public int[] range = new int[4] { 0, 0, 0, 0 };


    void Start() {
		Reroll();
    }

    public void Reroll() {
		health = 9 + dice.RollDice(3) + skills.HealthBuff;
		damage = 3 + skills.DamageBuff;
		hitChance = 0.90f;
		dodge = 5 + dice.RollDice(6);
		blightRes = 0.70f + skills.Resistence;
		stunRes = 0.60f + skills.Resistence;
		bleedRes = 0.70f + skills.Resistence;
		initiative = 8 + dice.RollDice(4);
    }

    // Update is called once per frame
    void Update() {

    }
}

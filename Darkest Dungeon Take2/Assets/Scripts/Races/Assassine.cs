using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Assassine : MonoBehaviour {

	public Skilltree skills;
    public Dice dice;

    public string className;
    public int health;
    public int damage;
    public float hitChance;
    public int dodge;
    public float blightRes;
    public float stunRes;
    public float bleedRes;
    public int initiative;
    public int[] range = new int[4] { 0, 0, 0, 0 };


    void Start() {
		Reroll ();
    }

    public void Reroll() {
		health = 7 + dice.RollDice(3) + skills.HealthBuff;
		damage = 5 + skills.DamageBuff;
		hitChance = 0.95f + skills.Hitchance;
		dodge = 10 + dice.RollDice(3);
		blightRes = 0.70f + skills.Resistence;
		stunRes = 0.60f + skills.Resistence;
		bleedRes = 0.70f + skills.Resistence;
		initiative = 9 + dice.RollDice(6);
    }

    // Update is called once per frame
    void Update() {

    }
}

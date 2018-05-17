using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Japaner : MonoBehaviour {
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
		className = "Japaner";
		health = 10 + dice.RollDice(3) + skills.AssHealth;
		damage = 2 + skills.AssDamage;
		hitChance = 0.90f + skills.Hitchance;
		dodge = 3 + dice.RollDice(6);
		blightRes = 0.70f + skills.Resistence;
		stunRes = 0.80f + skills.Resistence;
		bleedRes = 0.80f + skills.Resistence;
		initiative = 5 + dice.RollDice(4);
	}

	public void Reroll() {
		health = 12 + dice.RollDice(3)  + skills.AssHealth;
		dodge = 3 + dice.RollDice(6)  + dice.RollDice(6);
		initiative = 5 + dice.RollDice(4);
	}

	// Update is called once per frame
	void Update() {

	}
}

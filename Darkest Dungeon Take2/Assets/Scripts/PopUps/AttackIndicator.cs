using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIndicator : MonoBehaviour {

	//Made by Samuel

    float startTime;
    float duration;

    public int characterIndex;
    public int enemyIndex;
    public bool attackSide;         //true = player, false = enemy

    public float movementSpeed = 1.0f;

    public SpriteRenderer character;
    public SpriteRenderer enemy;

    public Races races;

	void Start () {
        races = GameObject.Find("RacesManager").GetComponent<Races>();
    }
	
	public void PopUp(float duration, int characterIndex, int enemyIndex, bool attackSide) {		//attacksŚide: true=character, false=enemy
        startTime = Time.time;
		this.duration = duration;
		this.characterIndex = characterIndex;
		this.enemyIndex = enemyIndex;
		this.attackSide = attackSide;
		races = GameObject.Find ("RacesManager").GetComponent<Races> ();	//erneut ausgeführt, da unklar, ob Start oder Funktion zuerst ausgeführt wird
		if (attackSide == true) {
			character.sprite = races.GetSprite (characterIndex, attackSide, true);
			enemy.sprite = races.GetSprite (enemyIndex, attackSide, false);
		} else {
			character.sprite = races.GetSprite (characterIndex, attackSide, false);
			enemy.sprite = races.GetSprite (enemyIndex, attackSide, true);
		}
    }

	void Update () {
		//Zerstörung nach gewisser Zeitspanne
        if (Time.time - startTime > duration) {
            Destroy(this.gameObject);
        }
		//je nachdem, welche Seite angreift, bewegt sich der Angreifer auf seinen Kontrahenten zu
		if (attackSide == true) {
			character.gameObject.transform.Translate (movementSpeed * Time.deltaTime, 0.0f, 0.0f);
		} else {
			enemy.gameObject.transform.Translate(-movementSpeed * Time.deltaTime, 0.0f, 0.0f);
		}
    }
}

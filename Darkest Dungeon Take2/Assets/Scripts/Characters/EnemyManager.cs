using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour {

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];
    public PlayerManager playerManager;

    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];
    public FightManager fightManager;
	public PopUpThings popUpThings;

    public string className = "empty";
    public int selected = 0;
    public int selectedEnemy = 0;

    bool[] alive = new bool[4] { true, true, true, true };

	void Start () {

	}
	
	void Update () {
		selected = playerManager.selected;
		selectedEnemy = playerManager.selectedEnemy;

		if(Input.GetKeyDown("l") ){
			Attack();
		}
	}

	public bool EnemyHit() {
		//überprüft, ob attacke glückt
		float hitChance = enemyCharacter[selectedEnemy].hitChance;
		float dodge = character[selectedEnemy].dodge/100f;
		Debug.Log("Hitchance = " + hitChance + "; Dodge = " + dodge);
		if (Random.Range(0.0f, 1.0f) < (hitChance-dodge)) {
			return true;
		} else {
			Debug.Log("Attack failed");
			return false;
		}
	}

	public void Attack() {
		int damage;
		damage = enemyCharacter [selectedEnemy].damage;
		if (EnemyHit () == true && enemyCharacter[selectedEnemy].health > 0 && character[selected].health > 0) {
			character [selected].health -= damage;
			popUpThings.attack (character [selected].playerIndex, enemyCharacter [selectedEnemy].enemyIndex, false);
		} else {
			popUpThings.attackFailed();
		}
	}

    public void CheckDead() {
        for (int i = 0; i < 4; i++) {
            if (enemyCharacter[i].health <= 0) {
                alive[i] = false;
            } else {
                alive[i] = true;
            }
        }
        
        if (alive[0] == false && alive[1] == false && alive[2] == false && alive[3] == false) {
            if (fightManager.wave == fightManager.maxWave) {
                fightManager.dungeonManager.dungeonLevel++;
                fightManager.LoadScene(1);
            } else {
                randomCharacters();
                fightManager.wave++;
                fightManager.UpdateData();
            }
        }
    }

    public void randomCharacters() {
        for (int i = 0; i < 4; i++) {
            enemyCharacter[i].enemyIndex = Random.Range(0, 5);
            enemyCharacter[i].UpdateStats();
			enemyCharacter [i].healthbar.SetActive (true);
        }
    }

	public void SetCharacter(int enemyIndex) {
        if (playerManager.selectedSide == 1) {
            //Debug.Log("!!!setCharacter enemy = " + charClass);
			enemyCharacter[selectedEnemy].enemyIndex = enemyIndex;
            enemyCharacter[selectedEnemy].UpdateStats();
        }
    }
}

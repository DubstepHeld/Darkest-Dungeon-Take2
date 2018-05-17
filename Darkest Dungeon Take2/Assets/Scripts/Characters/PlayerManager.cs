using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [Header("Characters")]
    public GameObject[] player = new GameObject[4];
    public Character[] character = new Character[4];

    public GameObject[] enemy = new GameObject[4];
    public EnemyCharacter[] enemyCharacter = new EnemyCharacter[4];

    [Header("Other Objects")]
	public Races races;
    public FightManager fightManager;
    public GameObject characterIcon;
    public Image image;
    public EnemyManager enemyManager;
    public PopUpThings popUpThings;
    public TransferVars transfer;

    [Header("Selected")]
    public int selected = 0;
    public int selectedEnemy = 0;
    public int prevSelected = 0;
    public int prevSelectedEnemy = 0;
    public int selectedSide = 0;
    public int prevSelectedSide = 0;

    public int damage;
    
    [Header("Save System")]
    public int saveslot = 0;
    public Button[] setSaveslotButtons;

    void Start() {
        transfer = GameObject.FindGameObjectWithTag("Transfer").GetComponent<TransferVars>();
        image = characterIcon.GetComponent<Image>();
        image.sprite = races.idleSprites[selected];
        character[selected].border.SetActive(true);
        enemyCharacter[selected].border.SetActive(true);

        for (int i = 0; i < 4; i++) {
            character[i].playerIndex = transfer.characterIndex[i];
        }
    }
	
	void Update () {
        damage = character[selected].damage + character[selected].GetComponent<CarriedItem>().weaponDamage;
        WhichSelected();
	}

    public void WhichSelected() {
        selectedEnemy = enemyManager.selectedEnemy;
        //aktualisiert rahmen
        if (selected != prevSelected) { 
            character[selected].border.SetActive(true);
            character[prevSelected].border.SetActive(false);
            prevSelected = selected;
            selectedSide = 0;
        }
        if (enemyManager.selectedEnemy != prevSelectedEnemy) {
            enemyCharacter[selectedEnemy].border.SetActive(true);
            enemyCharacter[prevSelectedEnemy].border.SetActive(false);
            prevSelectedEnemy = enemyManager.selectedEnemy;
            selectedSide = 1;
        }
    }

    public void Attack(int attackNum) {
        damage = character[selected].damage + character[selected].GetComponent<CarriedItem>().weaponDamage;
        if (Hit() == true && enemyCharacter[selectedEnemy].health > 0) {
            popUpThings.attack(character[selected].playerIndex, enemyCharacter[selectedEnemy].enemyIndex, true);
            if ((enemyCharacter[selectedEnemy].health - damage) <= 0) {
                popUpThings.GainXP(fightManager.dungeonManager.calcXP());
            }

            switch (attackNum) {
                case 0:
                    Attack1();
                    break;
                case 1:
                    Attack2();
                    break;
                case 2:
                    Attack3();
                    break;
                case 3:
                    Attack4();
                    break;
            }
            Debug.Log("Character " + selected + " attacks Enemy " + selectedEnemy + " with Attack " + attackNum);
        } else {
            popUpThings.attackFailed();
        }
    }

    //momentan alle attacken gleich
    public void Attack1() {
        //Attack1 stuff
        enemyCharacter[selectedEnemy].health -= damage;
    }
    public void Attack2() {
        //Attack2 stuff
        enemyCharacter[selectedEnemy].health -= damage;
    }
    public void Attack3() {
        //Attack3 stuff
        enemyCharacter[selectedEnemy].health -= damage;
    }
    public void Attack4() {
        //Attack4 stuff
        enemyCharacter[selectedEnemy].health -= damage;
    }

    public bool Hit() {
        //überprüft, ob attacke glückt
        float hitChance = character[selected].hitChance;
        float dodge = enemyCharacter[selectedEnemy].dodge/100f;
        Debug.Log("Hitchance = " + hitChance + "; Dodge = " + dodge);
        if (Random.Range(0.0f, 1.0f) < (hitChance-dodge)) {
            return true;
        } else {
            Debug.Log("Attack failed");
            return false;
        }
    }
    
	public void SetCharacter(int playerIndex) {
        //Character-Rasse aktualisieren
        if (selectedSide == 0) {
			character[selected].playerIndex = playerIndex;
            character[selected].UpdateStats();
        }
    }
    
	public void setSaveslot(int ss) {
        //saveslot festlegen, damit später verwendbar
		for (int i = 0; i < 4; i++) {
			if (i == ss)
				setSaveslotButtons [i].GetComponent<Image>().color = new Color32(0,255,255,255);
			else
				setSaveslotButtons [i].GetComponent<Image>().color = Color.white;
		}
		Debug.Log ("Saveslot set to " + ss);
		saveslot = ss;
	}

	public void Save() {
        //ruft datenspeicherfunktionen mit eben festgelegtem saveslot auf 
		SaveLoadManager.SavePlayer (character, saveslot);   //speichert alle charaktere
		SaveLoadManager.SaveEnemy (enemyCharacter, saveslot);   //speichert alle gegner
		SaveLoadManager.SaveGameData (fightManager, saveslot);  //speichert alle sonstigen daten/fortschritt
	}
		
	public void Load() {
        //auslesen und verteilung der gespeicherten werte
		for (int i = 0; i < 4; i++) {
			float[] loadedEnemyStats = SaveLoadManager.LoadEnemy (i, saveslot);
			enemyCharacter [i].enemyIndex = (int)loadedEnemyStats [4];
			enemyCharacter [i].UpdateStats ();
			enemyCharacter [i].health = (int)loadedEnemyStats [0];
			enemyCharacter [i].damage = (int)loadedEnemyStats [1];
			enemyCharacter [i].dodge = (int)loadedEnemyStats [2];
			enemyCharacter [i].initiative = (int)loadedEnemyStats [3];
			enemyCharacter [i].position = (int)loadedEnemyStats [5];
			enemyCharacter [i].hitChance = loadedEnemyStats [6];
			enemyCharacter [i].blightRes = loadedEnemyStats [7];
			enemyCharacter [i].stunRes = loadedEnemyStats [8];
			enemyCharacter [i].bleedRes = loadedEnemyStats [9];


			float[] loadedStats = SaveLoadManager.LoadPlayer (i, saveslot);
			character [i].playerIndex = (int)loadedStats [4];
			character [i].UpdateStats ();
			character [i].health = (int)loadedStats [0];
			character [i].damage = (int)loadedStats [1];
			character [i].dodge = (int)loadedStats [2];
			character [i].initiative = (int)loadedStats [3];
			character [i].position = (int)loadedStats [5];
			character [i].hitChance = loadedStats [6];
			character [i].blightRes = loadedStats [7];
			character [i].stunRes = loadedStats [8];
			character [i].bleedRes = loadedStats [9];
		}
        
        DungeonManager dungeonManager = fightManager.dungeonManager;
        float[] gameStats = SaveLoadManager.LoadGameData(saveslot);
        fightManager.wave = (int)gameStats[0];
        fightManager.gold = (int)gameStats[1];
        fightManager.volume = gameStats[2];
        dungeonManager.expLevel = (int)gameStats[3];
        dungeonManager.exp = (int)gameStats[4];
        dungeonManager.dungeonLevel = (int)gameStats[5];
        fightManager.UpdateData();
    }
}

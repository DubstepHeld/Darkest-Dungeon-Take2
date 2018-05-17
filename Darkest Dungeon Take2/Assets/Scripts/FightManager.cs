using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class FightManager : MonoBehaviour {

    [Header("Objekte")]
    public GameObject PopUpMenuParent;
    public GameObject PopUpMenu;
    public GameObject SettingsMenu;
    public GameObject SaveLoadMenu;
    
    public GameObject fightSystem;
    public GameObject levelText;

    public GameObject UIplayerManager;
    public GameObject UIenemyManager;
    public EnemyManager enemyManager;

    public DungeonManager dungeonManager;
    public PlayerManager playerManager;

    [Header("Variablen")]
    public int wave = 1;
    public int maxWave = 3;
    public int encounter = 0;
	public int gold = 0;
	public float volume = 1.0f;
    
    void Start() {
        UpdateData();
        enemyManager.randomCharacters();
    }

    void Update() {
        enemyManager.CheckDead();
        if (Input.GetKeyDown(KeyCode.Escape)) { //Wenn escape gedrückt, öffne oder schließe popupmenu
            if (PopUpMenuParent.activeSelf == true) {
                PopUpMenuParent.SetActive(false);
            }
            else if (PopUpMenuParent.activeSelf == false) {
                PopUpMenuParent.SetActive(true);
                PopUpMenu.SetActive(true);
                SettingsMenu.SetActive(false);
				SaveLoadMenu.SetActive (false);
            }
        }
    }

	public void UpdateData() {
		PopUpMenuParent.SetActive (false);
		if (wave > 0 && wave < maxWave) {
            levelText.GetComponent<Text>().text = "Wave " + wave;
			fightSystem.SetActive (true);
			UIenemyManager.SetActive (true);
		} else if (wave == maxWave) {
            levelText.GetComponent<Text>().text = "Final Wave";
        }
	}

    public void StartFight() {
		wave++;
        enemyManager.randomCharacters();
		UpdateData ();
    }

    public void ChangeVolume(float newVolume) {
        //Lautstärkeregler in PopUpMenu/SettingsMenu
        AudioListener.volume = newVolume;
		volume = newVolume;
    }

    public void ButtonPressed(int buttonIndex) {
        //buttons auslesen in Canvas/popupmenuparent/Dark background/Panel
        switch (buttonIndex) {
        case 0:                     //settings
            PopUpMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            break;
        case 1:                     //continue
            PopUpMenuParent.SetActive(false);
       		break;
        case 2:                     //return to main menu
            playerManager.setSaveslot(3);
            playerManager.Save();
            Application.Quit();
            break;
		case 3:                     //return to first page
			SettingsMenu.SetActive (false);
			SaveLoadMenu.SetActive (false);
            PopUpMenu.SetActive(true);
            break;
		case 4:                     //saveMenu
			SaveLoadMenu.SetActive (true);
			PopUpMenu.SetActive (false);
			break;
        }
    }


    public void LoadScene(int sceneIndex) {
        //Autosave, wenn programm geschlossen oder zurück zum MainMenu
        playerManager.setSaveslot(3);
        playerManager.Save();
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);   //Lade MainMenu
    }
}

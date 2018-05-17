using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject town;
    public GameObject blacksmithMenu;
    public GameObject tavernMenu;
    public GameObject guildMenu;
    public GameObject dlcMenu;

	// Use this for initialization
	void Start () {
        town.SetActive(true);
        blacksmithMenu.SetActive(false);
        tavernMenu.SetActive(false);
        guildMenu.SetActive(false);
        dlcMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToTown() {
        blacksmithMenu.SetActive(false);
        tavernMenu.SetActive(false);
        guildMenu.SetActive(false);
        town.SetActive(true);
    }

    public void ButtonPressed(int buttonIndex) {
        town.SetActive(false);
        switch (buttonIndex) {
            case 0: //blacksmith
                blacksmithMenu.SetActive(true);
                tavernMenu.SetActive(false);
                guildMenu.SetActive(false);
                dlcMenu.SetActive(false);
                break;
            case 1: //tavern
                blacksmithMenu.SetActive(false);
                tavernMenu.SetActive(true);
                guildMenu.SetActive(false);
                dlcMenu.SetActive(false);
                break;
            case 2: //guild
                blacksmithMenu.SetActive(false);
                tavernMenu.SetActive(false);
                guildMenu.SetActive(true);
                dlcMenu.SetActive(false);
                break;
            case 3:
                town.SetActive(true);
                blacksmithMenu.SetActive(false);
                tavernMenu.SetActive(false);
                guildMenu.SetActive(false);
                dlcMenu.SetActive(true);
                break;
        }
    }
}

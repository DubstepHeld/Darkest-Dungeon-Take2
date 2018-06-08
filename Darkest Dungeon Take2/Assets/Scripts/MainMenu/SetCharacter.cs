using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour {

	//Made by Samuel

    public GameObject[] players;
    public TransferVars transfer;
    public SimpleRaces races;
    public int selected;

	void Start () {
        transfer = GameObject.FindGameObjectWithTag("Transfer").GetComponent<TransferVars>();
	}

    public void SetActivePlayer(int index) {
        Debug.Log("Toll");
        selected = index;
        for (int i = 0; i < 4; i++) {   //border für geklicktes objekt anzeigen
            if (i == index) {
                players[index].transform.GetChild(0).gameObject.SetActive(true);
            } else {
                players[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    public void SetRace(int index) {
        transfer.characterIndex[selected] = index;  //zur übergabe
        players[selected].GetComponent<SpriteRenderer>().sprite = races.idle[index];    //anzeigebild
    }
}

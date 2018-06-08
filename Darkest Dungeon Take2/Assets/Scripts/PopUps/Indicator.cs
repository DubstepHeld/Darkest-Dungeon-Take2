using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {

	//Made by Samuel

    float startTime;
    float duration;
    int gainedXP;
    private GUIStyle guiStyle = new GUIStyle();
    int width = 200;
    int height = 200;

    int random1, random2;
    int randomRange = 50;

	void Update () {
		//Zerstörung nach Zeit duration
		if (Time.time - startTime > duration) {
            Destroy(this.gameObject);
        }
	}

    public void PopUp(float duration, int gainedXP) {
        startTime = Time.time;
        this.duration = duration;
        this.gainedXP = gainedXP;
        random1 = Random.Range(-randomRange, randomRange);
        random2 = Random.Range(-randomRange, randomRange);
    }

    void OnGUI() {
		//Zur Darstellung von GUI-Elementen
		//hier: Text
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((Screen.width/2-width/2) + random1, (Screen.height/2-height/2) + random2, width, height), "+" + gainedXP + "XP", guiStyle);
    }
}

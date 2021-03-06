﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFailedIndicator : MonoBehaviour {

	//Made by Samuel

    float startTime;
    float duration;
    private GUIStyle guiStyle = new GUIStyle();
    int width = 400;
    int height = 400;
    string failedText = "Attack Failed";

    public int yOffset = 50;

    void Update() {
		//wird nach Erstellung (Instantiate) nach Zeitspanne duration zerstört
        if (Time.time - startTime > duration) {
            Destroy(this.gameObject);
        }
    }

    public void PopUp(float duration) {
		//duration wird übergeben
        startTime = Time.time;
        this.duration = duration;
    }

    void OnGUI() {
		//Funktion zur Darstellung als GUI-Objekt
		//hier: Text
        guiStyle.fontSize = 70;
        guiStyle.normal.textColor = Color.white;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Label(new Rect((Screen.width / 2 - width/2), (Screen.height / 2 - height/2 + yOffset), width, height), failedText, guiStyle);
    }
}

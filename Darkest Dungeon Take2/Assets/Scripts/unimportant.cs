using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unimportant : MonoBehaviour {

	//Made by Samuel
	//Für den Ladebildschirm am Anfang (AlwaysLoadFirstTransferScene)

    float startTime;
	public float duration = 0.01f;

	void Start () {
        startTime = Time.time;
	}

	void Update () {
		if (Time.time - startTime > duration)
            SceneManager.LoadScene(1,LoadSceneMode.Single);
	}
}

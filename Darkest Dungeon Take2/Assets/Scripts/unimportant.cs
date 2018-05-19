using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class unimportant : MonoBehaviour {

    float startTime;
	public float duration = 0.01f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > duration)
            SceneManager.LoadScene(1,LoadSceneMode.Single);
	}
}

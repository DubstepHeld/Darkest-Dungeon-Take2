﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour {

    public void StartFight() {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}

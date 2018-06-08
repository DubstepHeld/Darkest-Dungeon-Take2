using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour {

	//made by Samuel

    public void StartFight() {
		//selbsterklärend
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}

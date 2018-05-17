using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferVars : MonoBehaviour {

    /*Not destroyed on load
     * used as variable transfer from scene to scene
     */

    [Header("Weapons")]
    public string[] weaponName;
    public int[] weaponTier;
    public int[] weaponDamage;

    [Header("Weapons")]
    public int[] characterIndex = new int[4] { 5, 5, 5, 5 };

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}

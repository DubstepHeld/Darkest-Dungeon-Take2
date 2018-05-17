using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacter : MonoBehaviour {

    /*fast völlig zweckfrei
     *nur zum auslesen, wenn objekt angeklickt wird 
     */

    public SetCharacter setChar;
    public int index;

    void OnMouseDown() {
        setChar.SetActivePlayer(index);
    }
}

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/// <summary>
/// This script will hold everything that is needed to be global only in Game scene
/// </summary>
public class GameplayScript : MonoBehaviour {
   

    void Awake() {

        Toolbox.Set_GameplayScript(this);
    }

    void Start() {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteListner : MonoBehaviour
{

    private void Start()
    {
        Toolbox.UserPrefs.Set_CurrentLevel(Toolbox.UserPrefs.Get_CurrentLevel() + 1);
    }

    public void OnPress_Home(){

        Toolbox.GameManager.Load_MenuScene();
    }

    public void OnPress_Next() {

        Toolbox.GameManager.Load_GameScene();
    }
}

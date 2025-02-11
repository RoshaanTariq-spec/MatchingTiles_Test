﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PauseListner : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;        
    }

    public void OnPress_Home()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.GameManager.Load_MenuScene();
    }

    public void OnPress_Restart()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.GameManager.Load_GameScene();
    }

    public void OnPress_Resume()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailListner : MonoBehaviour
{
    private void Start()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.levelFail);
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
}

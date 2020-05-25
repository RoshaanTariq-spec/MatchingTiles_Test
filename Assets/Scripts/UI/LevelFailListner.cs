using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailListner : MonoBehaviour
{
    public void OnPress_Home()
    {
        Toolbox.GameManager.Load_MenuScene();
    }

    public void OnPress_Restart()
    {
        Toolbox.GameManager.Load_GameScene();
    }
}

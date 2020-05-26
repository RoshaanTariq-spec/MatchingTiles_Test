using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDListner : MonoBehaviour
{
    public Text curMovesTxt;
    public Text maxMovesTxt;
    public Text levelTxt;

    private void Awake()
    {
        Toolbox.Set_HUD(this);
    }

    private void Start()
    {
        Set_CurMovesTxt(0);
        levelTxt.text = "Level = " + (Toolbox.UserPrefs.Get_CurrentLevel()+1).ToString();

    }

    public void Set_CurMovesTxt(int _val) {

        curMovesTxt.text = _val.ToString();
    }
    public void Set_MaxMovesTxt(int _val)
    {
        maxMovesTxt.text = _val.ToString();
    }

    public void OnPress_Pause() {

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);

        Toolbox.GameManager.InstantiateUI_Pause();
    }
}

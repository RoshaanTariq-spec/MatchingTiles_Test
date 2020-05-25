using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPrefs : MonoBehaviour
{
    private const string currentLevelPropertyName = "currentLevel";


    public int Get_CurrentLevel()
    {
        if (PlayerPrefs.HasKey(currentLevelPropertyName))
        {
            return PlayerPrefs.GetInt(currentLevelPropertyName);
        }
        else {

            Debug.LogError("There is no " + currentLevelPropertyName + " in Prefs");
            Set_CurrentLevel(0);
            return 0;
        }        
    }

    public void Set_CurrentLevel(int val) {

        PlayerPrefs.SetInt(currentLevelPropertyName, val);
    }

}

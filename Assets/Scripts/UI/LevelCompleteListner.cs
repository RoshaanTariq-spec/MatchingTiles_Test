using UnityEngine;

public class LevelCompleteListner : MonoBehaviour
{

    private void Start()
    {
        Toolbox.UserPrefs.Set_CurrentLevel(Toolbox.UserPrefs.Get_CurrentLevel() + 1);
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.levelComplete);
    }

    public void OnPress_Home(){

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.GameManager.Load_MenuScene();
    }

    public void OnPress_Next() {

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        Toolbox.GameManager.Load_GameScene();
    }
}

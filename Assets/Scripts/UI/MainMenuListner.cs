using UnityEngine;

public class MainMenuListner : MonoBehaviour
{

    public void OnPress_Play() {

        Toolbox.GameManager.Load_GameScene();
    }
}

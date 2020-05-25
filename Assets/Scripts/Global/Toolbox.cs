using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(Constants))]
[RequireComponent(typeof(UserPrefs))]

public class Toolbox : MonoBehaviour {
    private static GameManager gameManager;
    private static SoundManager soundManager;
    private static UserPrefs userPrefs;
    private static GameplayController gameplayController;
    private static HUDListner hudListner ;


    public static GameManager GameManager {
        get { return gameManager; }
    }

    public static SoundManager Soundmanager {
        get { return soundManager; }
    }
    
    public static UserPrefs UserPrefs
    {
        get { return userPrefs; }
    }

    public static GameplayController GameplayController
    {
        get { return gameplayController; }
    }

    public static HUDListner HUDListner
    {
        get { return hudListner; }
    }

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        soundManager = GetComponent<SoundManager>();
        userPrefs = GetComponent<UserPrefs>();
        DontDestroyOnLoad(gameObject);
    }

    public static void Set_GameplayScript (GameplayController _game) {
        gameplayController = _game;
    }

    public static void Set_HUD(HUDListner _hud)
    {
        hudListner = _hud;
    }
}
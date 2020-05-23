﻿using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(Constants))]
[RequireComponent(typeof(UserPrefs))]

public class Toolbox : MonoBehaviour {
    private static GameManager gameManager;
    private static SoundManager soundManager;
    private static UserPrefs userPrefs;
    private static GameplayScript gameplayScript;


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

    public static GameplayScript GameplayScript {
        get { return gameplayScript; }
    }

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        soundManager = GetComponent<SoundManager>();
        userPrefs = GetComponent<UserPrefs>();
        DontDestroyOnLoad(gameObject);
    }

    public static void Set_GameplayScript (GameplayScript game) {
        gameplayScript = game;
    }
}
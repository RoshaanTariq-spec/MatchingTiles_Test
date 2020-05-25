using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will hold everything that is needed to be global only in Game scene
/// </summary>
public class GameplayController : MonoBehaviour {

    public Transform layoutParent;
    public Sprite tileBackSideImg;

    public Action tileAction;

    private Sprite lastTileIcon;
    private TileController lastTileController;

    [SerializeField] private int score = 0;
    [SerializeField] private int requiredScore = 0;

    void Awake() {

        Toolbox.Set_GameplayScript(this);
    }

    void Start() {

        Initialize_Level();
    }

    public void Initialize_Level() {

        int curLevel = Toolbox.UserPrefs.Get_CurrentLevel();
        layoutParent.GetChild(curLevel).gameObject.SetActive(true);

        Transform curLayout = layoutParent.GetChild(curLevel);
        Level curLevelData = (Level)Resources.Load(Constants.scriptablesFolderPath + (curLevel + 1).ToString());
        
        requiredScore = curLevelData.images.Length;

        List<Sprite> tileImage = new List<Sprite>();
        Debug.Log("requiredScore = " + requiredScore);

        TileController[] tilesControllers = curLayout.GetComponentsInChildren<TileController>();

        foreach (var item in curLevelData.images)
        {
            tileImage.Add((Sprite) item);
            tileImage.Add((Sprite) item);
        }

        foreach (var item in tilesControllers)
        {
            Sprite randImg = tileImage[UnityEngine.Random.Range(0, tileImage.Count)];

            item.IconImg = randImg;
            tileImage.Remove(randImg);
        }
    }

    public void Check_ShowTile(Sprite _lastTileIcon, TileController _lastTileController)
    {
        if (lastTileIcon && lastTileController)
        {
            if (lastTileIcon == _lastTileIcon)
            {
                if (++score >= requiredScore) {

                    Debug.Log("Level Complete");
                    Debug.Log("RS = " + requiredScore);
                    Debug.Log("S = " + score);
                }

            }
            else {

                lastTileController.HideTile();
                _lastTileController.HideTile();
            }


            lastTileIcon = null;
            lastTileController = null;

        }
        else {

            lastTileIcon = _lastTileIcon;
            lastTileController = _lastTileController;

        }
    }
}

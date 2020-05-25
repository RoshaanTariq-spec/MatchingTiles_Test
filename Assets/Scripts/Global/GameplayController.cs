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

    [HideInInspector]
    [SerializeField] private int score = 0;
    [HideInInspector]
    [SerializeField] private int requiredScore = 0;


    [HideInInspector]
    [SerializeField] private int curMoves = 0;
    [HideInInspector]
    [SerializeField] private int maxMoves = 0;

    void Awake() {

        Toolbox.Set_GameplayScript(this);
    }

    void Start() {

        Initialize_Level();
    }


    /// <summary>
    /// Run in start and Completely hadnle the level initialization
    /// </summary>
    public void Initialize_Level() {

        int curLevel = Toolbox.UserPrefs.Get_CurrentLevel();
        layoutParent.GetChild(curLevel).gameObject.SetActive(true);

        Transform curLayout = layoutParent.GetChild(curLevel);
        Level curLevelData = (Level)Resources.Load(Constants.scriptablesFolderPath + (curLevel + 1).ToString());
        
        requiredScore = curLevelData.images.Length;
        maxMoves = curLevelData.maxMoves;

        Toolbox.HUDListner.Set_MaxMovesTxt(maxMoves);

        List<Sprite> tileImage = new List<Sprite>();
        TileController[] tilesControllers = curLayout.GetComponentsInChildren<TileController>();

        //Piling up all the images to be set into the level in a list
        foreach (var item in curLevelData.images)
        {
            tileImage.Add((Sprite) item);
            tileImage.Add((Sprite) item);
        }

        //Setting the images 1 - 1 to tiles in random order
        foreach (var item in tilesControllers)
        {
            Sprite randImg = tileImage[UnityEngine.Random.Range(0, tileImage.Count)];

            item.IconImg = randImg;
            tileImage.Remove(randImg);
        }
    }

    /// <summary>
    /// Complete checking of the tiles matching or keeping in stack to check the next one
    /// </summary>
    /// <param name="_tileIcon"> tile icon that is pressed</param>
    /// <param name="_tileController">tile controller that is pressed</param>
    public void Check_ShowTile(Sprite _tileIcon, TileController _tileController)
    {
        curMoves++;
        Toolbox.HUDListner.Set_CurMovesTxt(curMoves);

        if (lastTileIcon && lastTileController)
        {
            if (lastTileIcon == _tileIcon)
            {
                if (++score >= requiredScore) {

                    Toolbox.GameManager.InstantiateUI_LevelComplete();
                    return;
                }

            }
            else {

                lastTileController.HideTile();
                _tileController.HideTile();
            }


            lastTileIcon = null;
            lastTileController = null;

        }
        else {

            lastTileIcon = _tileIcon;
            lastTileController = _tileController;

        }

        if (curMoves >= maxMoves) {

            Toolbox.GameManager.InstantiateUI_LevelFail();
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Level")]
public class Level : ScriptableObject
{
    public int maxMoves = 5;
    public Sprite[] images;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Log", menuName = "Log")]
public class Log : ScriptableObject
{
    //public string name;
    public Sprite masterPiece;
    public int knivesNeeded = 10;
    public int appleChance = 25;
    public bool appleBool;
    public Sprite onePieceOfLog;
    public Sprite otherPieceOfLog;
    public Sprite thirdPieceOfLog;
    public Sprite fourthPieceOfLog;
    public float minLogPouseTime;
    public float maxLogPouseTime;
    public float minLogRotationTime;
    public float maxLogRotationTime;
    public float minLogRotationSpeed;
    public float maxLogRotationSpeed;
    public float minLogPouseSpeed;
    public bool dirChangeBool;
    public int intForDirChange;
    //public bool isBoss;
    //public Sprite afterBossKnife;
    public bool CountApplePercentage()
    {
        int randomNumber = Random.Range(1, 101);
        if(randomNumber > 0 && randomNumber < appleChance + 1)
        {
            appleBool = true;
        }
            return appleBool;
    }
}

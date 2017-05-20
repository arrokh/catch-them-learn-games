using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData : ScriptableObject
{
    public int score = 0;
    public LevelData[] levelData = new LevelData[3];
    public string targetScene = "";
}

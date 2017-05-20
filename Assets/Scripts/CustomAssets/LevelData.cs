using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LevelData 
{
    public string nameLevel;
    public bool openPreview,
                openEvaluation;
    public bool[] openLevel = new bool[5];
    public int[] lengthEnemy = new int[5];

}

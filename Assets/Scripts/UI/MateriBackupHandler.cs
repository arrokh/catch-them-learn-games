using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MateriBackupHandler : MonoBehaviour 
{
    [SerializeField]
    private Text text;

    private ProblemList problemList;

    [SerializeField]
    private int currentCategory;

	void Start () 
    {
        problemList = this.GetComponent<SwitchScene>().problemList;

        text.text = problemList.problem[currentCategory].preview;

        Debug.Log("MateriBackupHandler_currentCategory : " + currentCategory);
        this.GetComponent<SwitchScene>().userData.levelData[currentCategory].openLevel[0] = true;
	}
	
	void Update () 
    {
	
	}
}

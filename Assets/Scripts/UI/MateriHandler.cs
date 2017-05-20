using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class MateriHandler : MonoBehaviour 
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private LeanTweenType typeTween = LeanTweenType.easeOutBack;

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int currentCategory = 0;

    [SerializeField]
    private Text text;

    private ProblemList problemList;
    private UserData userData;

    public int countShow = 0;


	void Start () 
    {
        problemList = this.GetComponent<SwitchScene>().problemList;
        userData = this.GetComponent<SwitchScene>().userData;

	}
	
	void Update () 
    {
	
	}

    public void Show()
    {
        target.SetActive(true);
        Debug.Log("MateriHandler_currentCategory:" + currentCategory);
        Debug.Log("userData.score + countShow:" + userData.score + (countShow / 2));

        switch (Application.loadedLevelName)
        {
            case "Play_Backup":
                text.text = problemList.problem[currentCategory].materi[userData.score + (countShow / 2)];
                break;
            case "Play_Restore":
                text.text = problemList.problem[currentCategory].materi[(userData.score-5) + (countShow / 2)];
                break;
            case "Play_Recovery":
                text.text = problemList.problem[currentCategory].materi[(userData.score - 9) + (countShow / 2)];
                break;
            default:
                break;
        }

        
        target.transform.localScale = Vector3.zero;
        LeanTween.scale(target, Vector3.one, speed).setEase(typeTween);

        countShow++;
    }

    public void Close()
    {
        if (countShow >= 6)
        {
            switch (Application.loadedLevelName)
            {
                case "Play_Backup":
                    if (userData.score == 5)
                        userData.levelData[currentCategory].openEvaluation = true;
                    else
                    {
                        Debug.Log("Current level : " + userData.score);
                        userData.score++;
                        userData.levelData[currentCategory].openLevel[userData.score] = true;
                    }
                    break;
                case "Play_Restore":
                    if (userData.score == 9)
                        userData.levelData[currentCategory].openEvaluation = true;
                    else
                    {
                        Debug.Log("Current level : " + userData.score);
                        userData.score++;
                        userData.levelData[currentCategory].openLevel[userData.score-5] = true;
                    }

                    break;
                case "Play_Recovery":
                    if (userData.score == 13)
                        userData.levelData[currentCategory].openEvaluation = true;
                    else
                    {
                        Debug.Log("Current level : " + userData.score);
                        userData.score++;
                        userData.levelData[currentCategory].openLevel[userData.score - 9] = true;
                    }
                    break;
                default:
                    break;
            }

            

#if UNITY_EDITOR
            EditorUtility.SetDirty(userData);
            AssetDatabase.SaveAssets();
#endif
            this.GetComponent<SwitchScene>().ChangeScreen("Score");
        }
        else
            LeanTween.scale(target, Vector3.zero, speed).setEase(typeTween).setOnComplete(() => { target.SetActive(false);});

    }
}

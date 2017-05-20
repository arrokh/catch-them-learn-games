using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class BackupHandler : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] levelButton = new GameObject[5];

    [SerializeField]
    private GameObject evaluasiButton;

    [SerializeField]
    private int currentCategory;

    private UserData userData;

    public void Start()
    {
        userData = this.GetComponent<SwitchScene>().userData;

        for (int i = 0; i < 5; i++)
            levelButton[i].GetComponent<Button>().interactable = userData.levelData[currentCategory].openLevel[i];

        evaluasiButton.GetComponent<Button>().interactable = userData.levelData[currentCategory].openEvaluation;
    }

    public void SetLevelActive()
    {
        userData.levelData[0].openLevel[0] = true;
#if UNITY_EDITOR
        EditorUtility.SetDirty(userData);
        AssetDatabase.SaveAssets();
#endif
    }

    public void Update()
    {

    }



}

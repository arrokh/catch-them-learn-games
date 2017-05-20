using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CategoryHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] categoryButton = new GameObject[3];

    private UserData userData;

	void Start () 
    {
        userData = this.GetComponent<SwitchScene>().userData;

        for (int i = 0; i < 3; i++)
        {
            categoryButton[i].GetComponent<Button>().interactable = userData.levelData[i].openPreview;
        }
	}
}

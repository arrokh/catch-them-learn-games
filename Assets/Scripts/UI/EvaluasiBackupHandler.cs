using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class EvaluasiBackupHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private GameObject[] button = new GameObject[4];

    [SerializeField]
    private Text[] buttonText = new Text[4];

    [SerializeField]
    private Text question;

    [SerializeField]
    private Text finalText;

    [SerializeField]
    private int currentCategory = 0;

    private int count = 0,
                score = 0;

    private UserData userData;
    private ProblemList problemList;

    private bool isMoving = false;

    void Start()
    {
        userData = this.GetComponent<SwitchScene>().userData;
        problemList = this.GetComponent<SwitchScene>().problemList;

        SetText();

        if (finalPanel.activeInHierarchy)
            finalPanel.SetActive(false);
    }

    public void SetText()
    {
        LeanTween.rotateLocal(panel, new Vector3(180.0f, 0.0f, 0.0f), 0.0f);
        LeanTween.rotateLocal(panel, Vector3.zero, 2.0f).setEase(LeanTweenType.easeOutElastic).setOnStart(UpdateText).setOnComplete(() => { isMoving = false; });
    }

    public void UpdateText()
    {
        isMoving = true;
        question.text = problemList.problem[currentCategory].problem[count];

        for (int i = 0; i < 4; i++)
            buttonText[i].text = problemList.problem[currentCategory].chose[count].textAnswer[i];
    }

    public void CheckAnswer(string answer)
    {
        if (!isMoving)
        {
            if (count < 9)
            {
                string choseAnswer = "";

                switch (answer)
                {
                    case "a":
                        choseAnswer = buttonText[0].text;
                        break;
                    case "b":
                        choseAnswer = buttonText[1].text;
                        break;
                    case "c":
                        choseAnswer = buttonText[2].text;
                        break;
                    case "d":
                        choseAnswer = buttonText[3].text;
                        break;
                    default:
                        break;
                }

                if (choseAnswer == problemList.problem[currentCategory].answer[count])
                {
                    Debug.Log("Answer Right!");
                    score++;
                }

                count++;
                SetText();
            }
            else
            {
                LeanTween.moveLocalY(panel, 1500.0f, 1.0f).setEase(LeanTweenType.easeOutBack).setOnStart(() =>
                {
                    finalPanel.SetActive(true);
                    finalText.text = "NILAI\n" + (score * 10);
                    finalPanel.transform.localScale = Vector3.zero;
                    LeanTween.scale(finalPanel, Vector3.one, 1.0f).setEase(LeanTweenType.easeOutBack).setOnComplete(NextCategory);
                });
            }
        }
    }

    public void NextCategory()
    {
        userData.levelData[currentCategory + 1].openPreview = true;

#if UNITY_EDITOR
        EditorUtility.SetDirty(userData);
        AssetDatabase.SaveAssets();
#endif

        this.GetComponent<SwitchScene>().ChangeScreen("Main");
    }

}

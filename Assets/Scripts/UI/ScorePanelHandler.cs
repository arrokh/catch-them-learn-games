using UnityEngine;
using System.Collections;

public class ScorePanelHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backStar = new GameObject[3];

    [SerializeField]
    private GameObject[] foreStar= new GameObject[3];

    [SerializeField]
    private GameObject back;

    [SerializeField]
    private float speed = 0.5f;

	void Start () 
    {
        for (int i = 0; i < 3; i++)
            foreStar[i].transform.localScale = Vector3.zero;

        back.transform.localScale = Vector3.zero;

        LeanTween.scale(foreStar[0].gameObject, new Vector3(0.3f, 0.3f, 0.3f), speed).setDelay(0.25f + speed).setEase(LeanTweenType.easeOutBack).setOnComplete(ShowNext); ;
        LeanTween.scale(foreStar[1].gameObject, new Vector3(0.4f, 0.4f, 0.4f), speed).setDelay(0.5f + speed).setEase(LeanTweenType.easeOutBack).setOnComplete(ShowNext); ;
        LeanTween.scale(foreStar[2].gameObject, new Vector3(0.3f, 0.3f, 0.3f), speed).setDelay(0.75f + speed).setEase(LeanTweenType.easeOutBack).setOnComplete(ShowNext); ;
	}

    public void ShowNext()
    {
        LeanTween.scale(back, new Vector3(0.4f, 0.4f, 0.4f), speed).setEase(LeanTweenType.easeOutBack).setDelay(1.25f);
    }
}

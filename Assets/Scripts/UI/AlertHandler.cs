using UnityEngine;
using System.Collections;

public class AlertHandler : MonoBehaviour 
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private LeanTweenType typeTween = LeanTweenType.easeOutBack;

    [SerializeField]
    private float speed = 1.0f;

    void Start()
    {
        target.transform.localPosition = new Vector3(-1400.0f, 0.0f);
        if (!target.activeInHierarchy)
            target.SetActive(true);
    }

    public void Show()
    {
        target.transform.localPosition = new Vector3(-1400.0f, 0.0f);
        LeanTween.moveLocalX(target, 0.0f, speed).setEase(typeTween).setOnComplete(Close);
    }

    public void Close()
    {
        LeanTween.moveLocalX(target, -1400.0f, speed).setEase(typeTween).setDelay(1.0f);
    }
}

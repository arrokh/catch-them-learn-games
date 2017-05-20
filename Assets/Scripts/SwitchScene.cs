using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchScene : MonoBehaviour
{
    public UserData userData;
    public ProblemList problemList;

    public GameObject slider;

    private int loadProgress = 0;

	void Start ()
    {
        if (Application.loadedLevelName == "Loading")
        {
            slider = GameObject.Find("LoadingSlider");
            StartCoroutine(LoadingProgress(userData.targetScene));
        }
        
	}

    public void ChangeScreen(string scene)
    {
        userData.targetScene = scene;
        Application.LoadLevel("Loading");
        //Application.LoadLevel(scene);
    }

    IEnumerator LoadingProgress(string scene)
    {
        AsyncOperation async = Application.LoadLevelAsync(scene);
        while (!async.isDone)
        {
            loadProgress = (int)(async.progress * 100);
            slider.GetComponent<Slider>().value = loadProgress;
            yield return null;
        }
    }


}

using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateAssets : MonoBehaviour 
{
#if UNITY_EDITOR
    [MenuItem("Custom Menu/Create/User")]
    public static void CreateUser()
    {
        UserData user = ScriptableObject.CreateInstance<UserData>();

        AssetDatabase.CreateAsset(user, "Assets/Data/UserData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = user;
    }
    [MenuItem("Custom Menu/Create/Problem List")]
    public static void CreateProblemList()
    {
        ProblemList problemList = ScriptableObject.CreateInstance<ProblemList>();

        AssetDatabase.CreateAsset(problemList, "Assets/Data/ProblemList.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = problemList;
    }

#endif
}

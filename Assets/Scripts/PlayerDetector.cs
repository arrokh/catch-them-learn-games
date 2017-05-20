using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerDetector : MonoBehaviour 
{
    public GameObject mainCamera;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Coin")
        {
            Destroy(collider.gameObject);
            mainCamera.GetComponent<MateriHandler>().Show();
        }
        else if (collider.transform.parent.tag == "Border" || collider.tag == "Obstacle")
        {
            this.gameObject.transform.position = Vector3.zero;
            mainCamera.GetComponent<AlertHandler>().Show();
        }
    }
}

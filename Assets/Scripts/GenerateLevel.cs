using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour 
{
    [SerializeField]
    private GameObject coin,
                       obstacle;

    private Vector3 pos;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int random0 = Random.Range(-14, 14);
            if (random0 % 2 != 0)
                random0++;

            int random1 = Random.Range(-14, 14);
            if (random1 % 2 != 0)
                random1++;

            GameObject.Instantiate(coin, new Vector3(random0, 0.0f, random1), Quaternion.identity);
        }

    }
}

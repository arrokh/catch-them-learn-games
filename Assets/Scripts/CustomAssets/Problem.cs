using UnityEngine;
using System.Collections;

[System.Serializable]
public class Problem
{
    public string name;

    public string[] problem = new string[10];
    public Chose[] chose = new Chose[10];
    public string[] answer = new string[10];
    public string[] materi = new string[15];
    public string preview;
}
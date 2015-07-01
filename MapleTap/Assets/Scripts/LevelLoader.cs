using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public string defaultLevel = "Menu";
    public bool clickToLoad = true;

    void Update()
    {
        if (clickToLoad && Input.GetButtonDown("Action")) LoadLevel(defaultLevel);
    }

    public void LoadLevel(string l)
    {
        Application.LoadLevel(l);
    }
}
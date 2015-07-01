using UnityEngine;
using System.Collections;

public class LeavesColorChange : MonoBehaviour
{
    Material[] materials;
    // Use this for initialization
    Renderer renderer;

    int currentSeason = 0;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        materials = new Material[4];
        materials[0] = Resources.Load("", typeof(Material)) as Material;
        materials[1] = Resources.Load("", typeof(Material)) as Material;
        materials[2] = Resources.Load("", typeof(Material)) as Material;
        materials[3] = Resources.Load("", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSeason != GameController.controller.Season)
        {
            currentSeason = GameController.controller.Season;
            renderer.material = materials[currentSeason];
        }
    }
}

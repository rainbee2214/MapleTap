using UnityEngine;
using System.Collections;

public class GroundColorChange : MonoBehaviour
{
    public Color spring = Color.yellow,
                 summer = Color.green,
                 fall = Color.yellow,
                 winter = Color.grey;


    Renderer renderer;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        CalculateColor();
    }
    void CalculateColor()
    {
        int season = GameController.controller.Season;
        float scale = (GameController.controller.Day - (season * 91)) / 91f;
        switch (season)
        {
            case 0:
                renderer.material.color = Color.Lerp(spring, summer, scale);
                break;
            case 1:
                renderer.material.color = Color.Lerp(summer, fall, scale);
                break;
            case 2:
                renderer.material.color = Color.Lerp(fall, winter, scale);
                break;
            case 3:
                renderer.material.color = winter;
                break;
        }
        
    }
}

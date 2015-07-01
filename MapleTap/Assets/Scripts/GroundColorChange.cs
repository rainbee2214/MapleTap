using UnityEngine;
using System.Collections;

public class GroundColorChange : MonoBehaviour
{
    public Color spring = Color.yellow,
                 summer = Color.green,
                 fall = Color.yellow,
                 winter = Color.grey;

    Material material;

    // Use this for initialization
    void Start()
    {
        material = gameObject.GetComponent<Material>();
        InvokeRepeating("CalculateColor", 0.0f, GameController.controller.DayLength);
    }

    void CalculateColor()
    {
        int season = GameController.controller.Season;
        float scale = GameController.controller.Day / 92;
        switch (season)
        {
            case 0:
                material.color = Color.Lerp(spring, summer, scale);
                break;
            case 1:
                material.color = Color.Lerp(summer, fall, scale);
                break;
            case 2:
                material.color = Color.Lerp(fall, winter, scale);
                break;
            case 3:
                material.color = winter;
                break;
        }
        
    }
}

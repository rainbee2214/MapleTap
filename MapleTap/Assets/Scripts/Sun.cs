using UnityEngine;
using System.Collections;

//Used to move the sun around and cast shadows ? Will change with seasons
public class Sun : MonoBehaviour
{
    public float defaultXRotation = 50f,
                 defaultZRotation = 0f;

    public float minYRotation = 70.0f,
                 maxYRotation = -70.0f;

    void Start()
    {
        InvokeRepeating("RotateForDay", 0.0f, GameController.controller.DayLength);
    }

    void RotateForDay()
    {
        transform.rotation = Quaternion.Euler(defaultXRotation,
                                              Mathf.Lerp(minYRotation, maxYRotation, GameController.controller.Day / 365),
                                              defaultZRotation);
    }
}

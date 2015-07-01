using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour
{
    public float minYRotation = 70.0f,
                 maxYRotation = -70.0f;

    void Start()
    {
        InvokeRepeating("RotateForDay", 0.0f, GameController.controller.DayLength);
    }

    void RotateForDay()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x,
                                              Mathf.Lerp(minYRotation, maxYRotation, GameController.controller.Day / 365),
                                              transform.rotation.z);
    }

}

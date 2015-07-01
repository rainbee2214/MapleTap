using UnityEngine;
using System.Collections;

//Used to move the sun around and cast shadows ? Will change with seasons
public class Sun : MonoBehaviour
{
    public float defaultXRotation = 50f,
                 defaultZRotation = 0f;

    public float minYRotation = 70.0f,
                 maxYRotation = 270.0f;

    float speed = 1f;

    float increment;
    void Start()
    {
        transform.eulerAngles = new Vector3(defaultXRotation, minYRotation, defaultZRotation);
        StartCoroutine(RotateForDay());
        increment = 0.5f;
        Debug.Log(increment);
    }


    IEnumerator RotateForDay()
    {
        Vector3 rotation = Vector3.zero;
        float y = minYRotation;
        while (true)
        {
            y = transform.eulerAngles.y;
            y += increment;
            if (y >= maxYRotation || y <= minYRotation)
            {
                Debug.Log(y + " " + maxYRotation + " " + minYRotation);
                increment *= -1f;
            }
            rotation.Set(defaultXRotation, y, defaultZRotation);
            transform.eulerAngles = rotation;
            yield return null;
            //yield return new WaitForSeconds(GameController.controller.DayLength);
        }


    }
}

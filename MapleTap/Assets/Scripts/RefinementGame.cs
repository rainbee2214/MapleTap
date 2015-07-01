using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class RefinementGame : MonoBehaviour
{
    Scrollbar scrollbar;

    //[HideInInspector]
    public float speed = 1f;

    float target = 0f;
    float min = 0f;
    float max = 1f;
    [HideInInspector]
    public float delta = 0.05f;

    void Start()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        scrollbar.value = Mathf.Lerp(scrollbar.value, target, Time.deltaTime * speed);
        if (target == max && scrollbar.value > max - delta) target = min;
        if (target == min && scrollbar.value < min + delta) target = max;
    }

    public float GetPrecision()
    {
        return Mathf.Abs(0.5f - scrollbar.value);
    }
}

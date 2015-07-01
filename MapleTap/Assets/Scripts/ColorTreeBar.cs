using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This class lerps the color of a Unity UI's default slider.
/// Attach this to the "Fill" Game object that only contains and Image
/// as it automatically get's the default parent reference.
/// </summary>
public class ColorTreeBar : MonoBehaviour
{
    public Color empty = Color.red;
    public Color full = Color.green;

    Slider parentSlider;
    Image scrollBar;

    void Start()
    {
        parentSlider = transform.parent.parent.GetComponent<Slider>();
        scrollBar = gameObject.GetComponent<Image>();
        InvokeRepeating("CalculateColor", 0.0f, 0.1f);
    }

    void CalculateColor()
    {
        scrollBar.color = Color.Lerp(empty, full, parentSlider.value);
    }
}

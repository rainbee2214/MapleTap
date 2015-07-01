using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapleTree : MonoBehaviour
{
    [HideInInspector]
    public int id;

    public Slider slider;
    float growthRate = 50f;
    float decayDelay = 3f;
    float percentFull;

    int baseOutput = 1;
    float maxPotency;
    float minPotency;

    int level = 1;

    bool ableToTap = true;
    float increment = 0.1f;
    public bool grow = true;
    public bool clicked = false;


    void Start()
    {
        id = int.Parse(this.name.Substring(5));
        growthRate += Time.time;

    }

    void Update()
    {
        if (grow) StartCoroutine("Grow");
        if (clicked)
        {
            clicked = false;
            StopCoroutine("Grow");
            StartCoroutine("Clicked");
        }
    }

    public void SetupTree()
    {
        maxPotency = Random.Range(60, 100)/100f;
        minPotency = Random.Range(50, maxPotency * 100) / 100f;
        baseOutput = 1;
    }
    public void Tap()
    {
        if (ableToTap)
        {
            int output = GetOutput();
            GameController.controller.Tap(output, maxPotency, minPotency);
        }
        else
        {
            Debug.Log("Can't tap right now!");
        }
    }

    public int GetOutput()
    {
        return baseOutput * level;
    }

    void OnMouseDown()
    {
        Tap();
    }

    public void Upgrade()
    {
        baseOutput *= 2;
        Debug.Log("Upgrading " + this.name);
    }

    IEnumerator Grow()
    {
        float rand = Random.Range(0.5f, 1.5f);
        grow = false;
        int i = 0;
        while (i < growthRate)
        {
            i++;
            slider.value = i / growthRate;
            yield return new WaitForSeconds(increment*rand);
        }

        //print("Done growing.");

        yield return new WaitForSeconds(decayDelay);
        ableToTap = false;
        i = 0;
        while (i < growthRate)
        {
            i++;
            slider.value = 1-i / growthRate;
            yield return null;
        }
        //print("Dying");
        ableToTap = true;
        grow = true;
    }
    IEnumerator Clicked()
    {
        ableToTap = false;
        int i = 0;
        while (slider.value > 0)
        {
            i++;
            slider.value = 1-i / growthRate*2;
            yield return null;
        }
        ableToTap = true;
        grow = true;
    }
}

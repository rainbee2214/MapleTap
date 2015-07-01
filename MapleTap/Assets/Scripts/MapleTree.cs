using UnityEngine;
using System.Collections;

public class MapleTree : MonoBehaviour
{
    [HideInInspector]
    public int id;

    float maxGrowthRate = 10f;
    float minGrowthRate = 1f;
    float growthRate = 1f;
    float decayDelay = 3f;
    float percentFull;

    int baseOutput = 1;
    float maxPotency;
    float minPotency;

    int level = 1;

    void Start()
    {
        id = int.Parse(this.name.Substring(5));
        maxPotency = Random.Range(60, 100)/100f;
        minPotency = Random.Range(50, maxPotency * 100) / 100f;
        //Debug.Log(maxPotency + " " + minPotency);
    }

    public void Tap()
    {
        int output = baseOutput * level;
        GameController.controller.Tap(output);
        Debug.Log("Tapping tree " + id + " for " + output + " raw sap!");
    }

    void OnMouseDown()
    {
        Tap();
    }

    void Upgrade()
    {
        baseOutput *= 2;

    }
}

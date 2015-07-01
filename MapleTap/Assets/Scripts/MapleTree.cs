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
    }

    public void SetupTree()
    {
        maxPotency = Random.Range(60, 100)/100f;
        minPotency = Random.Range(50, maxPotency * 100) / 100f;
        baseOutput = Random.Range(1, 3);
    }
    public void Tap()
    {
        int output = GetOutput();
        GameController.controller.Tap(output);
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
        baseOutput += baseOutput/2;
        Debug.Log("Upgrading " + this.name);
    }
}

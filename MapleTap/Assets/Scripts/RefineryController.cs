using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefineryController : MonoBehaviour
{
    int unitSize = 10;
    float price = 10f;

    float refinementMultiplier = 1f;
    [HideInInspector]
    public float costToUpgrade = 500f;
    float costInflation = 1f;

    public void RefineAndSell()
    {
        Refine();
    }

    void Refine()
    {
        float totalPotency = 0f;
        for (int i = 0; i < unitSize; i++)
        {
            totalPotency += 100 * GameController.controller.rawSap[0].GetComponent<RawSap>().potency;
            GameController.controller.rawSap.RemoveAt(0);
        }
        Sell(price * (totalPotency / unitSize) * refinementMultiplier);
    }

    void Sell(float p)
    {
        Debug.Log("Sell price: " + p/unitSize);
        GameController.controller.Money = p;
    }

    public void Upgrade()
    {
        Debug.Log("Refining upgrade");
        unitSize += 10;
        refinementMultiplier *= 2;
        GameController.controller.Money = -costToUpgrade;
        costToUpgrade += (costToUpgrade * costInflation);
        costInflation += 0.25f;
    }
}

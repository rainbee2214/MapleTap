using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefineryController : MonoBehaviour
{
    RefinementGame refinementGame;

    [HideInInspector]
    public int unitSize = 10;
    float price = 10f;

    float precisionMultiplier = 1f;
    float refinementMultiplier = 1f;
    [HideInInspector]
    public float costToUpgrade = 500f;
    float costInflation = 1f;

    void Start()
    {
        refinementGame = GameObject.FindGameObjectWithTag("RefinementGame").GetComponent<RefinementGame>();
    }

    public void RefineAndSell()
    {
        if (GameController.controller.RawSap >= unitSize)
        {
            GameController.controller.RawSap = -unitSize;
            precisionMultiplier = 1 - refinementGame.GetPrecision();
            float cost = price * refinementMultiplier * precisionMultiplier;
            Sell(cost*unitSize);
        }
    }

    void Sell(float p)
    {
        Debug.Log("Sell price: " + p/unitSize);
        GameController.controller.Money = p;
        GameController.controller.TotalSales = unitSize;
        GameController.controller.TotalSalesPrices = p;
    }

    public void Upgrade()
    {
        GameController.controller.UpgradesBought = costToUpgrade;
        Debug.Log("Refining upgrade");
        unitSize += 10;
        refinementMultiplier *= 2;
        GameController.controller.Money = -costToUpgrade;
        costToUpgrade += (costToUpgrade * costInflation);
        price *= costInflation;
        costInflation += 0.25f;
        refinementGame.speed *= 3f / 4f;
        refinementGame.delta += 0.01f;
    }
}

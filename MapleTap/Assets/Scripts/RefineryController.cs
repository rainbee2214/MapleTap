using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefineryController : MonoBehaviour
{

    List<Asset> assets;
    List<GameObject> assetsGameObjects;
    float costToUpgrade;

    public GameObject assetGameObject;
    Asset asset;

    int assetCount = 6;

    public void Upgrade() { }

    void LoadAssets()
    {
        assets = new List<Asset>();
        assetsGameObjects = new List<GameObject>();
        for (int i = 0; i < assetCount; i++)
        {
            assets.Add(asset);
            assetsGameObjects.Add(Instantiate(assetGameObject) as GameObject);
            assetsGameObjects[i].name = assetGameObject.name + i;
            assetsGameObjects[i].transform.SetParent(transform);
        }

        foreach (Asset a in assets)
        {
            a.PrintName();
        }
        foreach (GameObject a in assetsGameObjects)
        {
            Debug.Log("Gameobject:" + a.name);
        }
    }
}

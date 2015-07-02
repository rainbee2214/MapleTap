using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeController : MonoBehaviour
{
    public List<GameObject> treesGameObjects;
    List<MapleTree> trees;

    public float costToUpgrade = 100f;
    float costInflation = 8f;
    GameObject treeGameObject;

    void Start()
    {
        trees = new List<MapleTree>();
        foreach (GameObject tree in treesGameObjects)
        {
            trees.Add(tree.GetComponent<MapleTree>());
            trees[trees.Count - 1].SetupTree();
        }
    }

    void Update()
    {

    }

    public void Upgrade() 
    {
        GameController.controller.UpgradesBought = costToUpgrade;
        GameController.controller.Money = -costToUpgrade;
        costToUpgrade += (costToUpgrade*costInflation);
        costInflation += 1f;
        foreach(MapleTree tree in trees)
        {
            tree.Upgrade();
        }
    }

    public void TapTree(int index)
    {
        trees[index].Tap();
    }

    public float GetAverageOutput()
    {
        float sum = 0f;
        foreach(MapleTree tree in trees)
        {
            sum += tree.GetOutput();
        }
        //Debug.Log(sum);
        return sum / (trees.Count * 1.0f);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeController : MonoBehaviour
{
    public List<GameObject> treesGameObjects;
    List<MapleTree> trees;
    float costToUpgrade;

    GameObject treeGameObject;

    int assetCount = 12;

    void Start()
    {
        trees = new List<MapleTree>();
        foreach (GameObject tree in treesGameObjects)
        {
            trees.Add(tree.GetComponent<MapleTree>());
        }
    }

    void Update()
    {

    }

    public void Upgrade() { }

    public void TapTree(int index)
    {
        trees[index].Tap();
    }

}

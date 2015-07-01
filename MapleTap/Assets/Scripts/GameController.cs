using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    [HideInInspector]
    public RefineryController refineryController;
    [HideInInspector]
    public TreeController treeController;

    #region Properties
    public int RawSap
    {
        get { return rawSap.Count; }
    }
    int refinedSyrup;
    public int RefinedSyrup
    {
        get { return refinedSyrup; }
        set { refinedSyrup += value; }
    }
    int time;
    public int Time
    {
        get { return time; }
        set { time += value; }
    }
    float money;
    public float Money
    {
        get { return money; }
        set { money += value; }
    }
    float debt;
    public float Debt
    {
        get { return debt; }
        set { debt += value; }
    }
    float maxMoney;
    public float MaxMoney
    {
        get { return maxMoney; }
        set { maxMoney += value; }
    }
    float maxDebt;
    public float MaxDebt
    {
        get { return maxDebt; }
        set { maxDebt += value; }
    }
    string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }
    #endregion

    public List<GameObject> rawSap;
    GameObject rawSapGameObject;

    int secondsPerDay = 5;

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        refineryController = GetComponentInChildren<RefineryController>();
        treeController = GetComponentInChildren<TreeController>();

        rawSap = new List<GameObject>();
        rawSapGameObject = Resources.Load("Prefabs/RawSap", typeof(GameObject)) as GameObject;
    }

    public int GetDay()
    {
        return time/secondsPerDay;
    }

    public void PayBank(float value)
    {
        //Won't be able to pay the bank unless there is some money in the account
        money -= value;
        debt -= value;
        if (debt < 0) debt = 0;
    }

    public void Tap(int numberOfSap)
    {
        for (int i = 0; i < numberOfSap; i++)
        {
            rawSap.Add(Instantiate(rawSapGameObject) as GameObject);
            rawSap[rawSap.Count - 1].name = "RawSap" + (rawSap.Count - 1);
            rawSap[rawSap.Count - 1].transform.SetParent(transform);
        }
        Debug.Log(rawSap.Count + " sap total.");
    }
}

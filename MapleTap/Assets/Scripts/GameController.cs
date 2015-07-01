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
    int time;
    public int Time
    {
        get { return time; }
        set { time += value; }
    }
    public int Day
    {
        get { return time / secondsPerDay; }
    }
    public int Season
    {
        get 
        {
            if (Day >= 275) return 3;
            else if (Day >= 183) return 2;
            else if (Day >= 91) return 1;
            else return 0;
        }
    }
    float money = 1000f;
    public float Money
    {
        get { return money; }
        set 
        { 
            if (money <= 0)
            {
                debt -= value;
            }
            else
            {
                money += value; 
                if (money < 0)
                {
                    debt -= money;
                    money = 0;
                }
                maxMoney = money > maxMoney ? money : maxMoney;
            }
        }
    }
    float debt = 1000000f;
    public float Debt
    {
        get { return debt; }
        set { debt += value; }
    }
    float maxMoney;
    public float MaxMoney
    {
        get { return maxMoney; }
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
    public float AverageSap
    {
        get
        {
            return treeController.GetAverageOutput();
        }
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

    public void PayBank(float value)
    {
        //Won't be able to pay the bank unless there is some money in the account
        money -= value;
        debt -= value;
        if (debt < 0) debt = 0;
    }

    public void Tap(int numberOfSap, float maxPotency, float minPotency)
    {
        for (int i = 0; i < numberOfSap; i++)
        {
            rawSap.Add(Instantiate(rawSapGameObject) as GameObject);
            rawSap[rawSap.Count - 1].name = "RawSap" + (rawSap.Count - 1);
            rawSap[rawSap.Count - 1].transform.SetParent(transform);
            rawSap[rawSap.Count - 1].GetComponent<RawSap>().potency = Random.Range(minPotency, maxPotency);
        }
    }
}

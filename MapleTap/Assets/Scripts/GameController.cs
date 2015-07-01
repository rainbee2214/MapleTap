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
    float rawSap;
    public float RawSap
    {
        get { return rawSap; }
        set { rawSap += value; }
    }
    int time;
    public int Time
    {
        get { return time; }
        set { time += value; }
    }
    float dayLength = 5f;
    public float DayLength
    {
        get { return dayLength; }
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

    //public List<GameObject> rawSap;
    GameObject rawSapGameObject;

    int secondsPerDay = 5;
    public bool startTime = false;

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

        //rawSap = new List<GameObject>();
        rawSapGameObject = Resources.Load("Prefabs/RawSap", typeof(GameObject)) as GameObject;
    }

    void Update()
    {
        if (startTime) StartCoroutine("StartTime");
    }

    public void PayBank(float value)
    {
        //Won't be able to pay the bank unless there is some money in the account
        money -= value;
        debt -= value;
        if (debt < 0) debt = 0;
    }

    public void Tap(float amount, float maxPotency, float minPotency, float minAmount, float maxAmount)
    {
        //rawSap += Random.Range(minAmount, maxAmount) * Random.Range(minPotency, maxPotency);
        rawSap += amount;
        Debug.Log(amount);
    }

    IEnumerator StartTime()
    {
        while (time < 365 * dayLength)
        {
            time++;
            yield return new WaitForSeconds(1f);
        }
    }
}

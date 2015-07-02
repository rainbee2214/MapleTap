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
    int totalSales;
    public int TotalSales
    {
        get { return totalSales; }
        set { totalSales += value; }
    }
    float totalSalesPrices;
    public float TotalSalesPrices
    {
        get { return totalSalesPrices; }
        set { totalSalesPrices += value; }
    }
    float rawSap;
    public float RawSap
    {
        get { return rawSap; }
        set { rawSap += value; }
    }
    float totalSap;
    public float TotalSap
    {
        get { return totalSap; }
        set { totalSap += value; }
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
        get { return 1+time / secondsPerDay; }
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
    public string SeasonName
    {
        get
        {
            switch (Season)
            {
                case 0: return "Spring";
                case 1: return "Summer";
                case 2: return "Autumn";
                case 3: return "Winter";
                default: return "Spring";
            }

        }
    }
    float money = 1000f;
    public float Money
    {
        get { return money; }
        set
        {
            if (value >= 0) moneyEarned += value;
            if (money <= 0 && value <= 0)
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
        get { return treeController.GetAverageOutput(); }
    }
    float sapSold;
    public float SapSold
    {
        get { return sapSold; }
    }
    float moneyEarned;
    public float MoneyEarned
    {
        get { return moneyEarned; }
    }
    float upgradesBought;
    public float UpgradesBought
    {
        get { return upgradesBought; }
        set { upgradesBought += value; }
    }
    int dayFinished;
    public int DayFinished
    {
        get { return dayFinished; }
    }
    public float NetEarnings
    {
        get { return Money-Debt;}
    }
    public float AverageSapPrice
    {
        get { return TotalSalesPrices/TotalSales; }
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
        totalSap += amount;
        Debug.Log(amount);
    }

    IEnumerator StartTime()
    {
        startTime = false;
        while (time < 365 * dayLength)
        {
            time++;
            yield return null;
            //yield return new WaitForSeconds(1f);
        }

        dayFinished = 365;
        Application.LoadLevel("Stats");
    }
}

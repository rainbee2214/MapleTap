using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    public RefineryController refineryController;
    public TreeController treeController;

    #region Properties
    int rawSap;
    public int RawSap
    {
        get { return rawSap; }
        set { rawSap += value; }
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

}

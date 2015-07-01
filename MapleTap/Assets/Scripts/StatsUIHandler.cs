using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsUIHandler : MonoBehaviour
{
    public Text nameText;
    public Text totalSapText;
    public Text averageSapText;
    public Text averagePriceText;
    public Text grossEarningsText;
    public Text netEarningsText;
    public Text upgradesBoughtText;
    public Text debtOwingText;
    public Text daysText;

    void Start()
    {
        nameText.text = GameController.controller.PlayerName;
        totalSapText.text = GameController.controller.TotalSap + " L";
        averageSapText.text = GameController.controller.AverageSap + " L";
        averagePriceText.text = "$"+GameController.controller.AverageSapPrice + " / L";
        grossEarningsText.text = "$" + GameController.controller.Money;
        upgradesBoughtText.text = "$" + GameController.controller.UpgradesBought;
        debtOwingText.text = "$"+GameController.controller.Debt;
        netEarningsText.text = "$"+GameController.controller.NetEarnings;
        daysText.text = ""+GameController.controller.DayFinished;
    }
}

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
        totalSapText.text = GameController.controller.TotalSap.ToString("0.00") + " L";
        averageSapText.text = GameController.controller.AverageSap.ToString("0.00") + " L";
        averagePriceText.text = "$" + GameController.controller.AverageSapPrice.ToString("0.00") + " / L";
        grossEarningsText.text = "$" + GameController.controller.Money.ToString("0.00");
        upgradesBoughtText.text = "$" + GameController.controller.UpgradesBought.ToString("0.00");
        debtOwingText.text = "$"+GameController.controller.Debt.ToString("0.00");
        netEarningsText.text = "$" + GameController.controller.NetEarnings.ToString("0.00");
        daysText.text = ""+GameController.controller.DayFinished;
    }
}

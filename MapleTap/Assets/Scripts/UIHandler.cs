using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text moneyText;
    public Text debtText;
    public Text sapAmountText;
    public Text avgSapAmountText;
    public Text upgradeTapPriceText;
    public Text upgradeRefineryPriceText;

    void Update()
    {
        sapAmountText.text = GameController.controller.RawSap + " L";
        avgSapAmountText.text = GameController.controller.AverageSap.ToString("0.00") + " L";
        upgradeTapPriceText.text = "Upgrade Tap" + Environment.NewLine + "$" + GameController.controller.treeController.costToUpgrade;
        upgradeRefineryPriceText.text = "Upgrade Refinery" + Environment.NewLine + "$" + GameController.controller.refineryController.costToUpgrade;
        moneyText.text = "$" + GameController.controller.Money;
        debtText.text = "$" + GameController.controller.Debt;

    }
}

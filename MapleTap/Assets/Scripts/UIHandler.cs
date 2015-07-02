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
    public Text sellunitText;
    public Text nameText;
    public Text dateText;
    public Text averagePriceText;

    public GameObject instructions;
    public Text inputNameText;
    
    void Update()
    {
        nameText.text = GameController.controller.PlayerName;
        dateText.text = "Day " + GameController.controller.Day + " - " + GameController.controller.SeasonName;
        sellunitText.text = GameController.controller.refineryController.unitSize + " L";
        sapAmountText.text = GameController.controller.RawSap.ToString("0.00") + " L";
        avgSapAmountText.text = GameController.controller.AverageSap.ToString("0") + " L";
        upgradeTapPriceText.text = "Upgrade Tap" + Environment.NewLine + "$" + GameController.controller.treeController.costToUpgrade.ToString("0");
        upgradeRefineryPriceText.text = "Upgrade Facilities" + Environment.NewLine + "$" + GameController.controller.refineryController.costToUpgrade.ToString("0");
        moneyText.text = "$" + GameController.controller.Money.ToString("0");
        debtText.text = "$" + GameController.controller.Debt.ToString("0");
        averagePriceText.text = "$" + GameController.controller.AverageSapPrice.ToString("0.00") + " / L";

        
    }

    public void HideInstructions()
    {
        GameController.controller.PlayerName = inputNameText.text.Length > 0 ? inputNameText.text : "John A. MacDonald";
        instructions.SetActive(false);
        GameController.controller.startTime = true;
    }
}

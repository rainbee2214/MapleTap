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

    public GameObject instructions;
    public Text inputNameText;
    
    void Update()
    {
        nameText.text = GameController.controller.PlayerName;
        dateText.text = "Day " + GameController.controller.Day + " - " + GameController.controller.SeasonName;
        sellunitText.text = GameController.controller.refineryController.unitSize + " L";
        sapAmountText.text = GameController.controller.RawSap.ToString("0.00") + " L";
        avgSapAmountText.text = GameController.controller.AverageSap.ToString("0.00") + " L";
        upgradeTapPriceText.text = "Upgrade Tap" + Environment.NewLine + "$" + GameController.controller.treeController.costToUpgrade;
        upgradeRefineryPriceText.text = "Upgrade Refinery" + Environment.NewLine + "$" + GameController.controller.refineryController.costToUpgrade;
        moneyText.text = "$" + GameController.controller.Money;
        debtText.text = "$" + GameController.controller.Debt;

        
    }

    public void HideInstructions()
    {
        GameController.controller.PlayerName = inputNameText.text.Length > 0 ? inputNameText.text : "John A. MacDonald";
        instructions.SetActive(false);
        GameController.controller.startTime = true;
    }
}

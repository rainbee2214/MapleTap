using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    
    public void UpgradeTrees() { GameController.controller.treeController.Upgrade(); }
    public void UpgradeRefinery() { GameController.controller.refineryController.Upgrade(); }
    public void RefineAndSell() { GameController.controller.refineryController.RefineAndSell(); }

}

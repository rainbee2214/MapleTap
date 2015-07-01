using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    
    public void UpgradeTrees()
    {
        GameController.controller.treeController.Upgrade();
    }

}

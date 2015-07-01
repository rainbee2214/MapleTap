using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseController : MonoBehaviour
{
    protected enum Type
    {
        Tree,
        Refinery
    }
    protected List<Asset> assets;
    protected float costToUpgrade;

    public virtual void Upgrade() { }

    protected void LoadAssets(Type assetType)
    {
        assets = new List<Asset>();
        switch (assetType)
        {
            case Type.Tree:
                {
                    //assets.Add();
                    break;
                }
            case Type.Refinery: break;
            default: break;
        }

    }
}

using UnityEngine;
using System.Collections;

public class Asset : MonoBehaviour
{
    protected int id;
    protected int currentOutput;
    public virtual void PrintName()
    {
        Debug.Log(this.name);
    }
}

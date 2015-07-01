using UnityEngine;
using System.Collections;

public class DeleteGameController : MonoBehaviour
{

    void Awake()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameController"));
    }
}

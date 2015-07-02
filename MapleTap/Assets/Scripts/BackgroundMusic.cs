using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
    public static BackgroundMusic bgMusic;

    void Awake()
    {
        if (bgMusic == null)
        {
            DontDestroyOnLoad(gameObject);
            bgMusic = this;
        }
        else if (bgMusic != this)
        {
            Destroy(gameObject);
        }
    }

}

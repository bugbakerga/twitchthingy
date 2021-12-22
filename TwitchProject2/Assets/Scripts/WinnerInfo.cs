using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerInfo : MonoBehaviour
{
    public static WinnerInfo instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public string winnername;
}

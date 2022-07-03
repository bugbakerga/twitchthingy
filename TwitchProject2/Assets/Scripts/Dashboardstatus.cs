using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashboardstatus : MonoBehaviour
{
    public Text streamer;

    void Awake()
    {
        streamer.text = "Welcome " + LoginInfo.instance.displayname + "!!!";
    }
}

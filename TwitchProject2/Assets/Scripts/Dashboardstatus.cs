using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashboardstatus : MonoBehaviour
{
    public Login logininfo;
    public Text streamer;

    void Awake()
    {
        streamer.text = "Logged in: " + logininfo.puser;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeSelection : MonoBehaviour
{
    public string equipedname;
    public Toggle visual;
    public Text visualtext;

    public bool isOn;
    int retrievednum;

    void Start()
    {
        retrievednum = PlayerPrefs.GetInt(equipedname, 1);
        if(retrievednum == 1)
        {
            isOn = true;
            visual.isOn = true;
            visualtext.text = "Equipped";
        }
        else
        {
            isOn = false;
            visual.isOn = false;
            visualtext.text = "Equip";
        }
    }

    public void Change()
    {
        if (isOn == true)
        {
            isOn = false;
            PlayerPrefs.SetInt(equipedname, 0);
            visual.isOn = false;
            visualtext.text = "Equip";
        }
        else
        {
            isOn = true;
            PlayerPrefs.SetInt(equipedname, 1);
            visual.isOn = true;
            visualtext.text = "Equipped";
        }
    }

}

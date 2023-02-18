using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CostumePicker : MonoBehaviour
{
    public GameObject[] costumes;
    public TextMeshProUGUI textDisplay;

    public ChickenHealth chickenHealth;

    public void chickinfo(string serial, string name)
    {
        textDisplay.text = name;
        chickenHealth.username = name;

        for (int i = 0; i < costumes.Length; i++)
        {
            if(serial == "!join " + i.ToString())
            {
                costumes[i].SetActive(true);
            }
        }
    }
}

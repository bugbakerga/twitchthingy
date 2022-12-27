using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CostumePicker : MonoBehaviour
{
    public GameObject[] costumes;
    public TextMeshProUGUI textDisplay;

    public void chickinfo(string serial, string name)
    {
        textDisplay.text = name;

        if (serial.Contains("!join 0"))
        {
            costumes[0].SetActive(true);
        }

        if (serial.Contains("!join 1"))
        {
            costumes[1].SetActive(true);
        }

        if (serial.Contains("!join 2"))
        {
            costumes[2].SetActive(true);
        }

        if (serial.Contains("!join 3"))
        {
            costumes[3].SetActive(true);
        }

        if (serial.Contains("!join 4"))
        {
            costumes[4].SetActive(true);
        }

        if (serial.Contains("!join 5"))
        {
            costumes[5].SetActive(true);
        }
    }
}

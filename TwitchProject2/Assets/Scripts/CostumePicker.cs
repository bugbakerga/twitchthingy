using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumePicker : MonoBehaviour
{
    public GameObject[] costumes;

    public void pickoutfit(int serial)
    {
        costumes[serial].SetActive(true);
    }
}

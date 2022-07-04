using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdelay : MonoBehaviour
{
    public GameObject hubui;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delaytime());
    }

    IEnumerator delaytime()
    {
        yield return new WaitForSeconds(4);
        hubui.SetActive(true);
    }
}

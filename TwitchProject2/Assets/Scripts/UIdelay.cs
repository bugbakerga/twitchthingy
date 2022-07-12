using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdelay : MonoBehaviour
{
    public GameObject hubui;

    public float delay = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delaytime());
    }

    IEnumerator delaytime()
    {
        yield return new WaitForSeconds(delay);
        hubui.SetActive(true);
    }
}

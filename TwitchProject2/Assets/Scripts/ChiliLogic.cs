using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiliLogic : MonoBehaviour
{
    public Chikenai chikenai;

    float chilitime = 0f;
    public Transform chilispawnpoint;
    public GameObject chilipoop;

    public float chilidecreasrate = 1f;

    bool failsafe;

    void Start()
    {
        failsafe = true;
    }

    public void addFiredmgTime()
    {
        chilitime += 45;
    }

    // Update is called once per frame
    void Update()
    {
        if (chilitime > 0)
        {
            chikenai.Boost();
            if (failsafe == true)
            {
                failsafe = false;
                chilitime -= chilidecreasrate;
                Instantiate(chilipoop, chilispawnpoint.position, Quaternion.identity);
                StartCoroutine(chilipoopreset());
            }
        }
        else
        {
            chikenai.UnBoost();
        }
    }

    IEnumerator chilipoopreset()
    {
        yield return new WaitForSeconds(0.1f);
        failsafe = true;
    }
}

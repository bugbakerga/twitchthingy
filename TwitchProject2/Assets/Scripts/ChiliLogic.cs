using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChiliLogic : MonoBehaviour
{
    public Chikenai chikenai;

    float chilitime = 0f;
    float maxchilitime = 0f;
    public Transform chilispawnpoint;
    public GameObject chilipoop;

    public float chilidecreasrate = 1f;

    bool failsafe;

    //Overhead stats
    public GameObject stat;
    public Image statefill;

    void Start()
    {
        failsafe = true;
    }

    public void addFiredmgTime()
    {
        chilitime += 45;
        maxchilitime += 45;
    }

    // Update is called once per frame
    void Update()
    {
        if (chilitime > 0)
        {
            stat.SetActive(true);
            statefill.fillAmount = chilitime / maxchilitime;
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
            maxchilitime = 0f;
            stat.SetActive(false);
        }
    }

    IEnumerator chilipoopreset()
    {
        yield return new WaitForSeconds(0.1f);
        failsafe = true;
    }
}

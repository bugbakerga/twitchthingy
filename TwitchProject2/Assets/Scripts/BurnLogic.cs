using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurnLogic : MonoBehaviour
{
    public ChickenHealth chickenHealth;

    public GameObject fire;
    float burnTime = 0f;
    float maxburnTime = 0f;
    public float burnDamage = 0.05f;

    public float burndecreaserate;

    //Overhead stats
    public GameObject stat;
    public Image statefill;

    bool burn;

    void Start()
    {
        burn = true;
    }

    public void addFiredmgTime()
    {
        burnTime += 6;
        maxburnTime += 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (burnTime > 0)
        {
            fire.SetActive(true);
            stat.SetActive(true);
            statefill.fillAmount = burnTime / maxburnTime;
            if (burn == true)
            {
                burn = false;
                burnTime -= burndecreaserate;
                chickenHealth.TakeDamage(burnDamage);
                StartCoroutine(glockSecond());
            }
        }
        else
        {
            fire.SetActive(false);
            maxburnTime = 0f;
            stat.SetActive(false);
        }
    }

    IEnumerator glockSecond()
    {
        yield return new WaitForSeconds(0.7f);
        burn = true;
    }
}

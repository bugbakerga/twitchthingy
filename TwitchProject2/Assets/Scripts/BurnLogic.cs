using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnLogic : MonoBehaviour
{
    public ChickenHealth chickenHealth;

    public GameObject fire;
    float burnTime = 0f;
    public float burnDamage = 0.05f;

    public float burndecreaserate;

    bool burn;

    void Start()
    {
        burn = true;
    }

    public void addFiredmgTime()
    {
        burnTime += 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (burnTime > 0)
        {
            fire.SetActive(true);
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
        }
    }

    IEnumerator glockSecond()
    {
        yield return new WaitForSeconds(0.7f);
        burn = true;
    }
}

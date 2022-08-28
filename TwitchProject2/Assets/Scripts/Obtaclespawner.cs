using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtaclespawner : MonoBehaviour
{
    public WinManager winManager;
    public GameObject[] obstacle;

    public Transform spawnposition;
    public Animator obsactleintro;

    int randomtime;
    int randomobject;
    bool failsafe;
    public int almosttime = 1;

    // Update is called once per frame
    void Update()
    {
        if (winManager.gamestarted == true)
        {
            if(failsafe == false)
            {
                failsafe = true;
                generateObstacle();
            }
        }
    }

    public void generateObstacle()
    {
        randomtime = Random.Range(10, 30);
        randomobject = Random.Range(0, 2);
        StartCoroutine(spawnobtacle());
    }

    IEnumerator spawnobtacle()
    {
        yield return new WaitForSeconds(randomtime);
        obsactleintro.SetTrigger("action");
        yield return new WaitForSeconds(almosttime);
        Instantiate(obstacle[randomobject], spawnposition.position, Quaternion.identity);
        generateObstacle();
    }
}

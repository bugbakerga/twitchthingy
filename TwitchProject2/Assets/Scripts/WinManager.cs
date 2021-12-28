using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    private int chickensLeft;
    public bool gamestarted;

    GameObject[] chickens;
    public WinnerInfo winnerInfo;

    // will soon be called or enabled on start of match
    void Start()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
    }

    void Update()
    {
        if(gamestarted == true)
        {
            chickens = GameObject.FindGameObjectsWithTag("Chiken");
            chickensLeft = chickens.Length;
            if (chickensLeft < 2)
            {
                chickens[0].gameObject.GetComponent<ChickenHealth>().invincible = true;
                Winlevel();
            }
        }

    }

    public void Winlevel()
    {
        winnerInfo.winnername = chickens[0].gameObject.GetComponent<Chickeninput>().username;
        SceneManager.LoadScene(2);
    }

}

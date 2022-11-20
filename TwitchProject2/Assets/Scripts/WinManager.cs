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


    public GameObject fadeobject;

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
        Time.timeScale = 0.4f;
        StartCoroutine(WinTime());
    }

    IEnumerator WinTime()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1);
        fadeobject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }

}

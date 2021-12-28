using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchStarter : MonoBehaviour
{
    private int chickensLeft;
    bool gamestarted;
    bool iscountingdown;

    GameObject[] chickens;

    public TextMeshProUGUI counter;
    public TextMeshProUGUI countdown;

    public WinManager winManager;

    // will soon be called or enabled on start of match
    void Start()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
        countdown.text = "";
    }

    void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
        chickensLeft = chickens.Length;
        if(chickensLeft > 11 && iscountingdown == false)
        {
            iscountingdown = true;
            StartCoroutine(Countsequence());
            counter.text = "";
        }
        else
        {
            counter.text = "Chat !join to play (" + chickensLeft + "/12)";
        }
    }

    IEnumerator Countsequence()
    {
        yield return new WaitForSeconds(3f);
        countdown.text = "3";
        yield return new WaitForSeconds(1f);
        countdown.text = "2";
        yield return new WaitForSeconds(1f);
        countdown.text = "1";
        yield return new WaitForSeconds(1f);
        countdown.text = "Go!";
        winManager.gamestarted = true;
        startchickens();
        yield return new WaitForSeconds(1f);
        countdown.text = "";
    }

    void startchickens()
    {
        for (int i = 0; i < chickensLeft; i++)
        {
            chickens[i].gameObject.GetComponent<Chikenai>().isStarted = true;
        }
    }

}

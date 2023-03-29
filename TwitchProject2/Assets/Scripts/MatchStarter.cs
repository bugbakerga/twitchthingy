using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchStarter : MonoBehaviour
{
    private int chickensLeft;
    bool gamestarted;
    bool iscountingdown;

    GameObject[] chickens;

    public Text counter;
    public GameObject counterobj;

    public Text countdown;
    public Animator countanim;
    public Animator costumeanim;

    public WinManager winManager;
    public MissionManager missionManager;

    AudioSource countsound;
    public AudioClip sound1;
    public AudioClip sound2;

    // will soon be called or enabled on start of match
    void Start()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
        countdown.text = "";
        countsound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
        chickensLeft = chickens.Length;
        if(chickensLeft > 11 && iscountingdown == false)
        {
            iscountingdown = true;
            StartCoroutine(Countsequence());
            counterobj.SetActive(false);
            costumeanim.SetTrigger("costumehide");
        }
        else
        {
            counter.text = "Chat !join to play (" + chickensLeft + "/12)";
        }
    }

    IEnumerator Countsequence()
    {
        yield return new WaitForSeconds(3f);
        countanim.SetTrigger("pop1");
        countdown.text = "3";
        countsound.PlayOneShot(sound1);
        yield return new WaitForSeconds(1f);
        countanim.SetTrigger("pop1");
        countdown.text = "2";
        countsound.PlayOneShot(sound1);
        yield return new WaitForSeconds(1f);
        countanim.SetTrigger("pop1");
        countdown.text = "1";
        countsound.PlayOneShot(sound1);
        yield return new WaitForSeconds(1f);
        countanim.SetTrigger("pop2");
        countdown.text = "Go!";
        winManager.gamestarted = true;
        startchickens();
        missionManager.startfirst();
        countsound.PlayOneShot(sound2);
        yield return new WaitForSeconds(0.9f);
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

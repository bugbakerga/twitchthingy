using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordLogic : MonoBehaviour
{
    float swordTime = 0f;
    public float sworddecreaserate;

    public Transform spawnpos;
    public GameObject slash;
    public Animator animator;

    public GameObject sword;
    public AudioSource sfxsource;
    public AudioClip clip;

    //Overhead icons
    public GameObject stat;
    public Text statText;

    public void addSwordTime()
    {
        swordTime += 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (swordTime > 0)
        {
            sword.SetActive(true);
            stat.SetActive(true);
            statText.text = swordTime.ToString();
        }
        else
        {
            sword.SetActive(false);
            stat.SetActive(false);
        }
    }

    public void SwordAction()
    {
        if(swordTime > 0)
        {
            swordTime -= sworddecreaserate;
            animator.SetTrigger("shoot");
            Instantiate(slash, spawnpos.position, spawnpos.rotation);
            sfxsource.PlayOneShot(clip);
        }
    }
}

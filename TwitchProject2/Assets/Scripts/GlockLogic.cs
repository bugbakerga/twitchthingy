using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlockLogic : MonoBehaviour
{
    float glockTime = 0f;
    public float glockDecreaserate;

    public Transform spawnpos;
    public ParticleSystem muzzle;
    public GameObject bullet;
    public Animator animator;

    public GameObject gun;
    public AudioSource sfxsource;
    public AudioClip clip;

    //Overhead icons
    public GameObject stat;
    public Text statText;

    bool shoot;

    void Start()
    {
        shoot = true;
    }

    public void addGlockTime()
    {
        glockTime += 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(glockTime > 0)
        {
            gun.SetActive(true);
            stat.SetActive(true);
            statText.text = glockTime.ToString();
            if(shoot == true)
            {
                shoot = false;
                glockTime -= glockDecreaserate;
                animator.SetTrigger("shoot");
                muzzle.Play();
                Instantiate(bullet, spawnpos.position, spawnpos.rotation);
                sfxsource.PlayOneShot(clip);
                StartCoroutine(glockSecond());
            }
        }
        else
        {
            gun.SetActive(false);
            stat.SetActive(false);
        }
    }

    IEnumerator glockSecond()
    {
        yield return new WaitForSeconds(1f);
        shoot = true;
    }
}

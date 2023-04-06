using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLaser : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;

    public GameObject parentobject;
    public GameObject explosion;

    //landing
    public GameObject dropEffect;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool hitground;
    bool spawnfx;

    void Update()
    {
        hitground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (hitground == true)
        {
            Drop();
        }
    }

    public void Drop()
    {
        if (spawnfx == false)
        {
            spawnfx = true;
            StartCoroutine(initialWait());
            Instantiate(dropEffect, transform.position, Quaternion.identity);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Explode()
    {
        Instantiate(explosion, parentobject.transform.position, Quaternion.identity);
        Destroy(parentobject);
    }

    IEnumerator initialWait()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("shoot");
    }
}

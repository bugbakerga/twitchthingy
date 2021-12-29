using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLaser : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;

    void Start()
    {
        StartCoroutine(initialWait());
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    IEnumerator initialWait()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("shoot");
    }
}

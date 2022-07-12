using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilStrike : MonoBehaviour
{
    public Animator animator;
    public Transform staffobject;

    public GameObject lightningeffect;
    public GameObject damageObject;

    GameObject[] chickens;

    int randnum;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetTrigger("power");
            StartCoroutine(strike());
        }
    }

    IEnumerator strike()
    {
        yield return new WaitForSeconds(1f);
        chickens = GameObject.FindGameObjectsWithTag("Chiken");
        randnum = Random.Range(0, chickens.Length);
        Instantiate(damageObject, chickens[randnum].transform.position, Quaternion.identity);
        staffobject.LookAt(chickens[randnum].transform.position);
        lightningeffect.SetActive(true);
    }
}

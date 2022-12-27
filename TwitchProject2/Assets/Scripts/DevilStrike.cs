using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilStrike : MonoBehaviour
{
    public Animator animator;
    public Transform staffobject;

    public GameObject lightningeffect;
    public GameObject damageObject;

    public GameObject destroyeffect;
    public GameObject parentobject;
    public GameObject dropEffect;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool hitground;
    bool spawnfx;

    GameObject[] chickens;

    int randnum;

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
            Instantiate(dropEffect, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            if(hitground == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                animator.SetTrigger("power");
                parentobject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                parentobject.gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(strike());
            }
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
        yield return new WaitForSeconds(2.5f);
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(parentobject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}

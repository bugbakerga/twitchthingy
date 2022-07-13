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

    GameObject[] chickens;

    int randnum;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetTrigger("power");
            parentobject.gameObject.GetComponent<Rigidbody>().useGravity = false;
            parentobject.gameObject.GetComponent<BoxCollider>().enabled = false;
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
        yield return new WaitForSeconds(2.5f);
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(parentobject);
    }
}

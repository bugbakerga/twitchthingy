using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public Transform parentpos;
    Vector3 plotpoint;

    int firelevel;
    public float speed;
    public float walkPointRange;

    public GameObject sparkle;
    public GameObject explosion;
    public GameObject parentobject;
    public GameObject poof;

    public Animator animator;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Instantiate(poof, parentpos.position, Quaternion.identity);
            findrandompos();
            firelevel += 1;
            StartCoroutine(triggerreset());
            animator.SetTrigger("move");
            if (firelevel > 1)
            {
                sparkle.SetActive(true);
            }

            if (firelevel > 2)
            {
                plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(1f);
                Instantiate(explosion, parentpos.position, Quaternion.identity);
                Destroy(parentobject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(firelevel > 0)
        {
            parentpos.position = plotpoint;
        }
    }

    public void findrandompos()
    {
        //calculate random point in range
        float ramdomZ = Random.Range(-walkPointRange, walkPointRange);
        float ramdomX = Random.Range(-walkPointRange, walkPointRange);

        plotpoint = new Vector3(ramdomX, parentpos.position.y, ramdomZ);
    }

    IEnumerator triggerreset()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}

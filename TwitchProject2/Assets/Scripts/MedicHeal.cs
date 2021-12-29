using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicHeal : MonoBehaviour
{
    public float heal;
    public GameObject parentobj;

    public Animator animator;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            plyr.gameObject.GetComponent<ChickenHealth>().Heal(heal);
            parentobj.gameObject.GetComponent<Rigidbody>().useGravity = false;
            parentobj.gameObject.GetComponent<BoxCollider>().enabled = false;
            animator.SetTrigger("outro");
            Destroy(parentobj, 1.5f);
        }
    }
}

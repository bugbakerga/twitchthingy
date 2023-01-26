using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicHeal : MonoBehaviour
{
    public float heal;
    public GameObject parentobj;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().Heal(heal);
            Destroy(parentobj);
        }
    }
}

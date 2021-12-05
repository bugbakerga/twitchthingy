using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenThreat : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHeal : MonoBehaviour
{
    public float heal;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().Heal(heal);
        }
    }
}

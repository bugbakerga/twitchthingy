using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devilkillbox : MonoBehaviour
{
    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(1f);
        }
    }
}

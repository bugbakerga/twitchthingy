using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPrize : MonoBehaviour
{
    public float damage;
    public GameObject explosion;
    public GameObject parentobj;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(parentobj);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordslashMove : MonoBehaviour
{
    public float slashSpeed = 10;

    public float slashdamage;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * slashSpeed;
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(slashdamage);
        }
    }
}

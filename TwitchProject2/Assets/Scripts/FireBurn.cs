using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurn : MonoBehaviour
{
    public float damage = 0.05f;

    void Start()
    {
        CameraShaker.instance.ShakeLarge();
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChickenHealth>().StartBurn(damage);
        }
    }
}

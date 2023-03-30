using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurn : MonoBehaviour
{

    void Start()
    {
        CameraShaker.instance.ShakeLarge();
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<BurnLogic>().addFiredmgTime();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlockCollect : MonoBehaviour
{
    public GameObject parentObject;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<GlockLogic>().addGlockTime();
            Destroy(parentObject);
        }
    }
}

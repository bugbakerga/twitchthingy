using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollect : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject collectgfx;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<SwordLogic>().addSwordTime();
            Instantiate(collectgfx, transform.position, Quaternion.identity);
            Destroy(parentObject);
        }
    }
}

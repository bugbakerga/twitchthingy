using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiliCollect : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject collectgfx;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            plyr.gameObject.GetComponent<ChiliLogic>().addFiredmgTime();
            Instantiate(collectgfx, transform.position, Quaternion.identity);
            Destroy(parentObject);
        }
    }
}

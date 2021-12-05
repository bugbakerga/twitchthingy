using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHitbox : MonoBehaviour
{
    public Chikenai theai;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Chiken")
        {
            theai.attackplayer();
        }
    }
}

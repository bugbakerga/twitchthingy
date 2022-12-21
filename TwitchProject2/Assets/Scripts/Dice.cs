using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Animator diceanim;
    public Transform dice;
    public float dicedamage;

    int randnum;
    bool canroll = true;
    public GameObject parentobj;
    public float animendtime;

    void OnTriggerEnter(Collider plyr)
    {
        if(canroll == true)
        {
            if (plyr.gameObject.tag == "Chiken")
            {
                randnum = Random.Range(0, 5);
                if (randnum == 0)
                {
                    dice.Rotate(0, 0, 0);
                    diceanim.SetTrigger("move");
                }
                if (randnum == 1)
                {
                    dice.Rotate(0, 90, 0);
                    diceanim.SetTrigger("move");
                }
                if (randnum == 2)
                {
                    dice.Rotate(0, -90, 0);
                    diceanim.SetTrigger("move");
                }
                if (randnum == 3)
                {
                    canroll = false;
                    plyr.gameObject.GetComponent<ChickenHealth>().TakeDamage(dicedamage);
                    dice.Rotate(90, 0, 0);
                    diceanim.SetTrigger("die");
                    Destroy(parentobj, animendtime);
                }
                if (randnum == 4)
                {
                    dice.Rotate(180, 0, 0);
                    diceanim.SetTrigger("move");
                }
                if (randnum == 5)
                {
                    dice.Rotate(-180, 90, -90);
                    diceanim.SetTrigger("move");
                }
            }
        }
    }
}

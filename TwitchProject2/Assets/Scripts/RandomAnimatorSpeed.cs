using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorSpeed : MonoBehaviour
{
    Animator targetanimator;

    public float minSpeed;
    public float maxSpeed;

    void Awake()
    {
        targetanimator = gameObject.GetComponent<Animator>();
        targetanimator.speed = Random.Range(minSpeed, maxSpeed);
    }


}

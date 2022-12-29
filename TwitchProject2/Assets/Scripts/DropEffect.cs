using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEffect : MonoBehaviour
{
    public GameObject dropEffect;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool hitground;
    bool spawnfx;

    void Update()
    {
        hitground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (hitground == true)
        {
            Drop();
        }
    }

    public void Drop()
    {
        if (spawnfx == false)
        {
            spawnfx = true;
            Instantiate(dropEffect, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}

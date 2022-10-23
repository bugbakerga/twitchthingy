using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBlast : MonoBehaviour
{
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject shatter;

    bool hitground;
    bool explode;

    void Update()
    {
        hitground = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (hitground == true)
        {
            spawnfire();
        }
    }

    public void spawnfire()
    {
        if(explode == false)
        {
            explode = true;
            Instantiate(shatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}

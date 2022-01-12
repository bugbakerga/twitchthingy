using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public Animator animator;

    public void ShakeSmall()
    {
        int rng = Random.Range(0, 1);

        if (rng == 0)
        {
            animator.SetTrigger("shakesm1");
        }

        if (rng == 1)
        {
            animator.SetTrigger("shakesm2");
        }
    }
}

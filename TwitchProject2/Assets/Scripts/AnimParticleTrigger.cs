using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParticleTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void TriggerFX()
    {
        particleSystem.Play();
    }
}

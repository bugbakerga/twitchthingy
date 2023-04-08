using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    public Animator uianimator;
    
    public void TriggerUI()
    {
        uianimator.SetTrigger("show");
    }
}

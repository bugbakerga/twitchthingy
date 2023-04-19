using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    public Animator uianimator;
    public int maxAnims = 2;

    Animator MainAnimator;
    
    void Start()
    {
        int animIndex = Random.Range(1, maxAnims);
        MainAnimator = gameObject.GetComponent<Animator>();
        MainAnimator.SetInteger("WinAnim", animIndex);
    }
    
    public void TriggerUI()
    {
        uianimator.SetTrigger("show");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotiManager : MonoBehaviour
{
    public static NotiManager instance;

    public CameraShaker cameraShaker;

    public TextMeshProUGUI deathbox;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }

    public void addNotification(string user)
    {
        deathbox.text = deathbox.text + "\n" + user + " has perished!";
        cameraShaker.ShakeSmall();
        animator.SetTrigger("joined");
    }

    public void addAppearence(string prizename)
    {
        deathbox.text = deathbox.text + "\n" + "A " + prizename + " has appeared!" ;
        animator.SetTrigger("joined");
    }
}

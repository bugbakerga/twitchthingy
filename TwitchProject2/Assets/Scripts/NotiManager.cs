using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotiManager : MonoBehaviour
{
    public static NotiManager instance;

    public CameraShaker cameraShaker;

    public GameObject popupprefab;
    public Transform noticontent;

    public Texture2D deadicon;
    public Texture2D spawnedicon;

    private void Awake()
    {
        instance = this;
    }

    public void addNotification(string user)
    {
        string notiuser = user + " has perished!";
        Instantiate(popupprefab, noticontent).GetComponent<Notification>().SetNoti(notiuser, deadicon);
        cameraShaker.ShakeSmall();
    }

    public void addAppearence(string prizename)
    {
        string notiappear = "A " + prizename + " has appeared!";
        Instantiate(popupprefab, noticontent).GetComponent<Notification>().SetNoti(notiappear, spawnedicon);
    }
}

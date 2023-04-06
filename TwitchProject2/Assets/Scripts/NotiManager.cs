using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotiManager : MonoBehaviour
{
    public static NotiManager instance;

    public GameObject popupprefab;
    public Transform noticontent;

    public Sprite deadicon;
    public Sprite spawnedicon;

    private void Awake()
    {
        instance = this;
    }

    public void addNotification(string user)
    {
        string notiuser = user + " has perished!";
        Instantiate(popupprefab, noticontent).GetComponent<Notification>().SetNoti(notiuser, deadicon);
        CameraShaker.instance.ShakeSmall();
    }

    public void addAppearence(string prizename)
    {
        string notiappear = "A " + prizename + " has appeared!";
        Instantiate(popupprefab, noticontent).GetComponent<Notification>().SetNoti(notiappear, spawnedicon);
    }
}

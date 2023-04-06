using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text notitext;
    public Image notiimage;

    public void SetNoti(string name, Sprite icon)
    {
        notitext.text = name;
        notiimage.sprite = icon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text notitext;
    public RawImage notiimage;

    public void SetNoti(string name, Texture2D icon)
    {
        notitext.text = name;
        notiimage.texture = icon;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showhide : MonoBehaviour
{
    public GameObject secrettext;
    Text visibility;

    bool isvisible = false;

    void Awake()
    {
        visibility = gameObject.GetComponent<Text>();
        visibility.text = "<";
        secrettext.SetActive(false);
    }

    public void showorhide()
    {
        if(isvisible == false)
        {
            isvisible = true;
            secrettext.SetActive(true);
            visibility.text = ">";
        }
        else
        {
            isvisible = false;
            secrettext.SetActive(false);
            visibility.text = "<";
        }
    }
}
